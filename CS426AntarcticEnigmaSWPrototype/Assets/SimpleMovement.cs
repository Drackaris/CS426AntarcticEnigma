using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleMovement : MonoBehaviour
{

    public float speed = 25.0f;
	public float rotationSpeed = 90;
	public float force = 700f;
    private float barSpeed = 10;
    private float speed1 = 20;
    private float speed2 = 40;
    private float speed3 = 50;
    public int PuzzlePieceDirection;
	private CameraSwitch camswitch;
	public GameObject PuzzleBlock;
	private GameObject PuzzlePiece;
    private GameObject Bar;
    public GameObject Cube;
    public GameObject Trap1;
    public GameObject Trap2;
    public GameObject Trap3;
    private Vector3 SpawnLocation;
	public List<string> LevelCommands;
	public List<string> TaskList;
	Rigidbody rb;
	Transform t;
	public Day_TimeScript dt;


	public int GameMode; //0 if player controled 1 for computer 2 for kitchen....etc.....
	public bool CanGoToComputer;
    public bool CanGoToKitchen;
    public bool CanGoToTV;
    public bool CanGoToRadio;
    public bool CanGetTaskList;
	public bool CanGiveInput;
	public int ComputerPuzzleAttempts;
	public bool CanGoToSleep;
	public bool LookingAtCanvas;
	public bool CanLookAtSchedule;
	public bool CanKillEnemy;

	private bool CorrectEnemy;

	public bool GotTasksToday;

    public int chances = 0;
    public int counter = 0;
    public int onGreen = 0;
    public bool kDone = false;
    public int inK = 0;

	public List<int> SecuritySystemArr;

    public AcceptSound acceptS;
    public MissSound missS;

    public TMPro.TextMeshProUGUI canvasText;
    public Canvas canvas;
    public GameObject panel;

    public int StartOfGame;
    public int StartOfKitchen;
    public int StartOfComp;
    public int StartOfPuzzT;
	public int StartOfRadio;

    public WinSound wS;
    public LoseSound lS;

    public bool securityDone = false;

	public int TutorialValue;

    public Canvas KitchenC;
    public TMPro.TextMeshProUGUI kitchenText;
    public TMPro.TextMeshProUGUI puzzThreeText;

    public string input = "";
    public int switchingIReset = 0;

    public bool puzzThree = false;

    public int Day = 1;
    public static int fails = 0;

    public SaveSystem save;

    // Use this for initialization
    void Start()
	{
		rb = GetComponent<Rigidbody>();
		t = GetComponent<Transform>();
		GameMode = 0;
		CanGoToComputer = false;
        CanGoToKitchen = false;
		CanGetTaskList = false;
        CanGoToTV = false;
		CanGiveInput = false;
		CanGoToSleep = false;
		GotTasksToday = false;
		CanKillEnemy = false;
		CorrectEnemy = false;
        PuzzlePieceDirection = 1;
		camswitch = GameObject.FindGameObjectWithTag("GameController").GetComponent<CameraSwitch>();
		PuzzlePiece = GameObject.FindGameObjectWithTag("ComputerStartTag");
        Bar = GameObject.FindGameObjectWithTag("Bar");
        Cube = GameObject.FindGameObjectWithTag("puzzle4");
        Trap1 = GameObject.FindGameObjectWithTag("Trap1");
        Trap2 = GameObject.FindGameObjectWithTag("Trap2");
        Trap3 = GameObject.FindGameObjectWithTag("Trap3");
        dt = GameObject.Find("TimeController").GetComponent<Day_TimeScript>();
        SpawnLocation = new Vector3(PuzzlePiece.transform.position.x, PuzzlePiece.transform.position.y, PuzzlePiece.transform.position.z);
		LevelCommands = new List<string>();
		TaskList = new List<string>();
		SecuritySystemArr = new List<int>();
		ComputerPuzzleAttempts = 1;

		CanLookAtSchedule = false;

        canvasText = canvas.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        kitchenText = KitchenC.GetComponentInChildren<TMPro.TextMeshProUGUI>();
		TutorialValue = 0;
        StartOfGame = 1;
        StartOfKitchen = 0;
        StartOfComp = 0;
        StartOfPuzzT = 0;
		StartOfRadio = 0;

        kitchenText.SetText("");
        puzzThreeText.SetText("");
    }

	// Update is called once per frame
	void Update()
	{
        if (Input.GetKey(KeyCode.Equals))
        {
            SceneManager.LoadScene(5); //GO back to menu
        }

        if (GameMode == 0)
		{
            if (StartOfGame == 1)
            {
				LookingAtCanvas = true;
				if (dt.day == 0)
				{
					canvasText.SetText("This is your fist day working at The Antarctic Resesarch Base. The captain will be showing you around and what your responsibilities are starting with storing data in the computer. To start the task, go up to the computer and press 'Space-Bar'. If you understand press 'c', and good luck!");
					AddTutorialTasks();
					TutorialValue = 1;
				}
				else if (dt.day == 1)
				{
					canvasText.SetText("This is your fist day working at the Antarctic research base, your first goal is to read the task list. (Going up to it and pressing space).  You can also check everyone's on the wall. (Also pressing space bar) " +
					   "After that you should feel free to explore the base and do the tasks you are asked of. To start a puzzle, go up to the object and press 'Space-Bar'. If you understand press 'c', and good luck!");
				}
				else if (dt.day == 2)
				{
					canvasText.SetText("Another team member has gone missing during the night, we will need to continue the functioning of the base for us all to survive but we must keep a more watchful eye on each team member.");
				}
                StartOfGame = 0;
                panel.SetActive(true);
            }
			if(TutorialValue == 2)
			{
					
				canvasText.SetText("Outstanding Job! We will now move on to learning how to prepare food.  Follow me!");
				panel.SetActive(true);
			}
			if(TutorialValue == 3)
			{
				canvasText.SetText("Outstanding Job! We will now move on to how to reboot our security system when it goes down.  Follow me!");
				panel.SetActive(true);
			}
			if(TutorialValue == 4)
			{
				canvasText.SetText("Outstanding Job! We will now move on to fixing the radio system when it goes down. Follow me!");
				panel.SetActive(true);
			}
			if (TutorialValue == 5)
			{
				canvasText.SetText("Outstanding Job! Feel free to explore the base and when you ready for tomorrow just go to bed! (Go to the bed and press space.) Tomorrow is an exciting day!");
				panel.SetActive(true);
			}

			if (Input.GetKey(KeyCode.C))
            {
                panel.SetActive(false);
                canvasText.SetText("");
				if(TutorialValue != 0)
				{
					TutorialValue = 1;
				}
				LookingAtCanvas = false;
            }

            if (Input.GetKey(KeyCode.J))
            {
                GameMode = 3;
            }

            if (Input.GetKey(KeyCode.W))
				rb.velocity += this.transform.forward * speed * Time.deltaTime;
			else if (Input.GetKey(KeyCode.S))
				rb.velocity -= this.transform.forward * speed * Time.deltaTime;

			if (Input.GetKey(KeyCode.D))
				rb.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
			else if (Input.GetKey(KeyCode.A))
				rb.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);

			if (Input.GetKeyDown(KeyCode.X))
			{
				if(CorrectEnemy)
				{
					GameMode = 7;
					canvasText.SetText("Congrats you have killed the correct enemy.  Press 'c' to continue");
					panel.SetActive(true);
				}
				else
				{
					GameMode = 7;
					canvasText.SetText("You have failed, you killed the wrong enemy.  Press 'c' to continue");
					panel.SetActive(true);
				}
			}

			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (CanGoToComputer)
				{
					if(dt.hour>=22)
					{
						canvasText.SetText("You are feeling too tired to do this task, you must sleep.  Press 'c' to continue");
						panel.SetActive(true);
					}
					else if (TaskList.Contains("Store Data In The Computer"))
					{
						Debug.Log("Trying to switch camera.");
						camswitch.GoToComputerCamera();
						GameMode = 1;
						CanGiveInput = true;
					}
				}

                if (CanGoToKitchen)
                {
					if (dt.hour >= 22)
					{
						canvasText.SetText("You are feeling too tired to do this task, you must sleep.  Press 'c' to continue");
						panel.SetActive(true);
					}
					else if (TaskList.Contains("Cook Food In The Kitchen"))
                    {
                        Debug.Log("Trying to switch camera.");
                        camswitch.GoToKitchenCamera();
                        GameMode = 2;
                    }
                }

                if (CanGoToTV)
                {
					if (dt.hour >= 22)
					{
						canvasText.SetText("You are feeling too tired to do this task, you must sleep.  Press 'c' to continue");
						panel.SetActive(true);
					}
					else if (TaskList.Contains("Fix Security System"))
                    {
                        Debug.Log("Trying to switch camera.");
                        camswitch.GoToPuzzleThree();
                        GameMode = 3;
                    }
                }

                if (CanGoToRadio)
                {
					if (dt.hour >= 22)
					{
						canvasText.SetText("You are feeling too tired to do this task, you must sleep.  Press 'c' to continue");
						panel.SetActive(true);
					}
					else if (TaskList.Contains("Fix Radio"))
                    {
                        Debug.Log("Trying to switch camera.");
                        camswitch.GoToPuzzleFour();
                        GameMode = 5;
                    }
                }
                if (CanGoToSleep)
				{
					if (GotTasksToday)
					{
						if (TaskList.Count > 0)
						{

							if (dt.hour > 22)
							{
								Day++;
								fails++;
								save.SaveGame(2, fails);
								SceneManager.LoadScene(2);

							}
							else
							{
								canvasText.SetText("You still have time to get your tasks done!  Try to finish. (Press 'c' to close this window)");
								panel.SetActive(true);
							}
						}

						else
						{
							//TODO: Call the script that increments the day
							if (dt.day == 0)
							{
								SceneManager.LoadScene(4);
							}
							else
							{
								Day++;
								save.SaveGame(2, fails);
								SceneManager.LoadScene(2);
							}
						}
					}
					else
					{
						canvasText.SetText("Got get tasks for the day and attempt to complete them! (Press 'c' to close this window)");
						panel.SetActive(true);
					}
				}
                if (CanGetTaskList)
				{
					if (TaskList.Count == 0)
					{
						GameMode = 4;
                    }
				}
				if(CanLookAtSchedule)
				{
					GameMode = 6;
				}
            }


        }
		else if (GameMode == 1)
		{

            if (StartOfComp == 0)
            {
                canvasText.SetText("You have 3 attempts to solve the puzzle.  How the puzzle works is you give input W to go forward, D to rotate the piece right, a to rotate the piece left and tab to attempt to solve.\nIf you don't make it in 3 attempts or hit a black square you will fail the puzzle. If you understand press 'c', and good luck!");
                panel.SetActive(true);
                StartOfComp = 1;
            }

            if (Input.GetKey(KeyCode.C))
            {
                panel.SetActive(false);
                canvasText.SetText("");
            }

            PuzzlePiece = GameObject.FindGameObjectWithTag("ComputerStartTag");
			if (CanGiveInput)
			{
				if (Input.GetKeyDown(KeyCode.W))
				{
					LevelCommands.Add("F");

				}
				if (Input.GetKeyDown(KeyCode.A))
				{
					LevelCommands.Add("L");

				}
				if (Input.GetKeyDown(KeyCode.D))
				{
					LevelCommands.Add("R");

				}
			}
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				ComputerPuzzleAttempts++;
				StartCoroutine(AttemptSolvePuzzle());		
			}

			if(Input.GetKey(KeyCode.Escape))
			{
				camswitch.GoToPlayerCamera();
				ComputerPuzzleAttempts = 1;
				GameMode = 0;
                StartOfComp = 0;
			}
		}
        else if (GameMode == 2)
        {
            if (StartOfKitchen == 0)
            {
                canvasText.SetText("In this puzzle you will use 'A' and 'D' to move between pots. Use the space-bar to get the slider on the green, and the selected pot will stop burning. If you understand press 'c', and good luck!");
                panel.SetActive(true);
                StartOfKitchen = 1;
            }

            if (Input.GetKey(KeyCode.C))
            {
                panel.SetActive(false);
                canvasText.SetText("");
            }

            kitchenText.SetText("Attempts for this fire " + chances + "\n" + "Completed " + counter + " out of 4");

            inK = 1;
            camswitch.GoToKitchenCamera();
            float pos = Bar.transform.localPosition.z;
            if (pos > 8 || pos < 1)
                barSpeed = -1 * barSpeed;
            Bar.transform.Translate(0, 0, barSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (pos >= 4.1 && pos <= 4.8)
                {
                    Bar.transform.Translate(0, 0, 0);

                    barSpeed = 15;
                    chances  = 0;
                    onGreen = 1;

                    if(kDone)
                    {
                        inK = 0;
                        GameMode = 0;
                        camswitch.GoToPlayerCamera();
						if(TutorialValue != 0)
						{
							TutorialValue = 3;
						}
                        kDone = false;
                        StartOfKitchen = 0;
                        chances = 0;
                        wS.audioSource.Play();
						TaskList.Remove("Cook Food In The Kitchen");
                        kitchenText.SetText("");
                        //counter = 0;

                    }

                    acceptS.audioSource.Play();

                }
                else
                {
                    if (barSpeed > 0)
                        barSpeed = barSpeed - 2;
                    else
                        barSpeed = barSpeed + 2;

                    if(chances == 10)
                    {
                        inK = 0;
                        GameMode = 0;
                        camswitch.GoToPlayerCamera();
                        kDone = false;
                        StartOfKitchen = 0;
                        chances = 0;
                        //counter = 0;
                        lS.audioSource.Play();
                        kitchenText.SetText("");

                    }


                    chances += 1;
                    missS.audioSource.Play();
                }
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                Bar.transform.Translate(0, 0, 0);
                camswitch.GoToPlayerCamera();
                barSpeed = 15;
                GameMode = 0;
                inK = 0;
                StartOfKitchen = 0;
                lS.audioSource.Play();
                kitchenText.SetText("");
                chances = 0;
            }
        }
        else if (GameMode == 3)
        {
            puzzThree = false;
            camswitch.GoToPuzzleThree();

            if(switchingIReset == 1)
            {
                input = " ";
                switchingIReset = 0;
            }
            if (StartOfPuzzT == 0)
            {
                canvasText.SetText("In this puzzle you will be using the number 1-4. You want to remember the sequence of the blocks lighting up. Left(1) All the way on Right(4). Enter your input after the sequence ends and wait to see how you did. If you understand press 'c', and good luck!");
                panel.SetActive(true);
                StartOfPuzzT = 1;
            }
			if(Input.GetKeyDown(KeyCode.Alpha1))
			{
				SecuritySystemArr.Add(1);
                input += "1, ";
                puzzThreeText.SetText(input);
			}
			if(Input.GetKeyDown(KeyCode.Alpha2))
			{
				SecuritySystemArr.Add(2);
                input += "2, ";
                puzzThreeText.SetText(input);
            }
			if(Input.GetKeyDown(KeyCode.Alpha3))
			{
				SecuritySystemArr.Add(3);
                input += "3, ";
                puzzThreeText.SetText(input);
            }
			if(Input.GetKeyDown(KeyCode.Alpha4))
			{
				SecuritySystemArr.Add(4);
                input += "4, ";
                puzzThreeText.SetText(input);
            }
            if (Input.GetKey(KeyCode.C))
            {
                panel.SetActive(false);
                canvasText.SetText("");
            }
            if (Input.GetKey(KeyCode.Escape) || securityDone)
            {
                puzzThree = true;      
                camswitch.GoToPlayerCamera();
                GameMode = 0;
                StartOfPuzzT = 0;
                securityDone = false;
                puzzThreeText.SetText("");
            }
        }
		else if (GameMode == 4)
		{
			canvasText.SetText("Select Three Tasks (Only one of each)" + "\n1.) Store data in the computer." + "\n2.) Cook food in the kitchen." + "\n3.)Fix the security system." + "\n4.)Fix the Radio.");
			panel.SetActive(true);
			if(Input.GetKeyDown(KeyCode.Alpha1))
			{
				if(!TaskList.Contains("Store Data In The Computer"))
				TaskList.Add("Store Data In The Computer");
			}
			else if(Input.GetKeyDown(KeyCode.Alpha2))
			{
				if(!TaskList.Contains("Cook Food In The Kitchen"))
				TaskList.Add("Cook Food In The Kitchen");
			}
			else if(Input.GetKeyDown(KeyCode.Alpha3))
			{
				if(!TaskList.Contains("Fix Security System"))
				TaskList.Add("Fix Security System");
			}
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (!TaskList.Contains("Fix Radio"))
                    TaskList.Add("Fix Radio");
            }
            if (TaskList.Count == 3)
			{
				panel.SetActive(false);
				canvasText.SetText("");
				GotTasksToday = true;
				GameMode = 0;
			}
		}
        else if (GameMode == 5)
        {

            camswitch.GoToPuzzleFour();

			if (StartOfRadio == 0)
			{
				canvasText.SetText("For this puzzle you will have to get over to the green bar on the opposite side.  You can move left or right with 'A' and 'D', move forward with 'W' and backwards with 'S', but try not to hit the moving bars. If you understand press 'c', and good luck!");
				panel.SetActive(true);
				StartOfRadio = 1;
			}

			if (Input.GetKey(KeyCode.C))
			{
				panel.SetActive(false);
				canvasText.SetText("");
			}

			float pos1 = Trap1.transform.localPosition.x;
            float pos2 = Trap2.transform.localPosition.x;
            
            if (pos1 >= 4 || pos1 <= -4)
                speed1 = -1 * speed1;
            if (pos2 >= 4 || pos2 <= -4)
                speed2 = -1 * speed2;

            Trap1.transform.Translate(speed1 * Time.deltaTime, 0f, 0f);
            Trap2.transform.Translate(speed2 * Time.deltaTime, 0f, 0f);
            if (TutorialValue != 1)
            {
                float pos3 = Trap3.transform.localPosition.x;
                if (pos3 >= 4 || pos3 <= -4)
                    speed3 = -1 * speed3;
                Trap3.transform.Translate(speed3 * Time.deltaTime, 0f, 0f);
            }

            Cube.transform.Translate(10f * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 10f * Input.GetAxis("Vertical") * Time.deltaTime);
        }
		else if (GameMode == 6)
		{
			if (LookingAtCanvas == false)
			{
				canvasText.SetText("Select the schedule you would like to look at. \n1.)Blue \n2.)Red \n3.)Green \n(Press 'c' to exit)");
			}
			panel.SetActive(true);
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				canvasText.SetText("Security: 10:00-12:00 \n Computer: 14:00-16:00 \nKitchen: 18:00-20:00 \nSleeping:24:00-8:00");
				LookingAtCanvas = true;
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				canvasText.SetText("Sleeping 2:00-11:00 \nRadio 11:00-13:00 \nKitchen 16:00-18:00 \nComputer 18:00-20:00");
				LookingAtCanvas = true;
			}
			 if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				canvasText.SetText("Kitchen 8:00-10:00 \nSleeping 10:00-18:00 \nSecurity 18:00-20:00 \nComputer 20:00-22:00");
				LookingAtCanvas = true;
			}
			if(Input.GetKeyDown(KeyCode.C))
			{
				panel.SetActive(false);
				LookingAtCanvas = false;
				GameMode = 0;
			}
		}
		else if (GameMode == 7)
		{
			if(Input.GetKey(KeyCode.C))
			{
				save.SaveGame(1, fails);
				SceneManager.LoadScene(5);
			}
		}

    }

	public IEnumerator AttemptSolvePuzzle()
	{
		foreach (string str in LevelCommands)
		{
			yield return new WaitForSeconds(0.5f);
			if (str == "F")
			{
				if (PuzzlePieceDirection == 1)
				{
					PuzzlePiece.transform.position = new Vector3(PuzzlePiece.transform.position.x, PuzzlePiece.transform.position.y, PuzzlePiece.transform.position.z + 1);
				}
				else if (PuzzlePieceDirection == 2)
				{
					PuzzlePiece.transform.position = new Vector3(PuzzlePiece.transform.position.x + 1, PuzzlePiece.transform.position.y, PuzzlePiece.transform.position.z);
				}
				else if (PuzzlePieceDirection == 3)
				{
					PuzzlePiece.transform.position = new Vector3(PuzzlePiece.transform.position.x, PuzzlePiece.transform.position.y, PuzzlePiece.transform.position.z - 1);
				}
				else if (PuzzlePieceDirection == 4)
				{
					PuzzlePiece.transform.position = new Vector3(PuzzlePiece.transform.position.x - 1, PuzzlePiece.transform.position.y, PuzzlePiece.transform.position.z);
				}
			}
			else if(str == "L")
			{
				PuzzlePiece.transform.Rotate(0, -90f, 0, Space.Self);
				PuzzlePieceDirection = GetRotationValue(PuzzlePiece);
			}
			else if(str == "R")
			{
				PuzzlePiece.transform.Rotate(0, 90f, 0, Space.Self);
				PuzzlePieceDirection = GetRotationValue(PuzzlePiece);
			}
		}
		if(GameMode==1)
		{
			if (ComputerPuzzleAttempts > 3)
			{
				ResetPuzzlePiece();
				ComputerPuzzleAttempts = 1;
			}
		}
		LevelCommands.Clear();
	}

	public void ResetPuzzlePiece()
	{
		Destroy(PuzzlePiece);
		PuzzlePieceDirection = 1;
		Instantiate(PuzzleBlock, SpawnLocation, Quaternion.identity);
		LevelCommands.Clear();
	}

	public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Computer")
		{
			CanGoToComputer = true;
		}
		if(other.tag == "SlideDoor")
		{
			Animator animator = other.GetComponent<Animator>();
			animator.SetTrigger("DoorOpen");
		}
        if (other.tag == "pan")
        {
            CanGoToKitchen = true;
        }
        if (other.tag == "TV")
        {
            CanGoToTV = true;
        }
		if (other.tag == "Bed")
		{
			CanGoToSleep = true;
		}
		if (other.tag == "Task")
		{
			CanGetTaskList = true;
		}
        if (other.tag == "Radio")
        {
            CanGoToRadio = true;
        }
		if(other.tag == "Schedule")
		{
			CanLookAtSchedule = true;
		}
		if(other.tag.Contains("NPC"))
		{
			CanKillEnemy = true;
			if(other.tag == "RedNPC")
			{
				CorrectEnemy = true;
			}
			else
			{
				CorrectEnemy = false;
			}
		}

    }

	public void OnTriggerExit(Collider other)
	{
		if(other.tag == "Computer")
		{
			CanGoToComputer = false;
		}

        if (other.tag == "pan")
        {
            CanGoToKitchen = false;
        }

        if (other.tag == "TV")
        {
            CanGoToTV = false;
        }

		if(other.tag == "Bed")
		{
			CanGoToSleep = false;
		}

        if (other.tag == "Task")
		{
			CanGetTaskList = false;
		}

        if (other.tag == "Radio")
        {
            CanGoToRadio = false;
		}
		if (other.tag == "Schedule")
		{
			CanLookAtSchedule = false;
		}
		if(other.tag.Contains("NPC"))
		{
			CanKillEnemy = false;
			CorrectEnemy = false;
		}
	}

	public void AddTutorialTasks()
	{
		TaskList.Add("Store Data In The Computer");
		TaskList.Add("Cook Food In The Kitchen");
		TaskList.Add("Fix Security System");
        TaskList.Add("Fix Radio");
    }

	public int GetRotationValue(GameObject PuzzlePiece)
	{
		int val = 0;
		if(PuzzlePiece.transform.rotation.y == 0)
		{
			val = 1;
		}
		else if (PuzzlePiece.transform.rotation.eulerAngles.y > 89.00 && PuzzlePiece.transform.rotation.eulerAngles.y < 91 )
		{
			val = 2;
		}
		else if ( PuzzlePiece.transform.rotation.eulerAngles.y > 179 && PuzzlePiece.transform.rotation.eulerAngles.y < 181)
		{
			val = 3;
		}
		else
		{
			val = 4;
		}
		return val;
	}

    public void EndPuzzleFour()
    {
        Trap1.transform.localPosition = new Vector3(0f, 0f, -2.2f);
        Trap2.transform.localPosition = new Vector3(0f, 0f, 0.5f);
        if (TutorialValue != 1)
        {
            Trap3.transform.localPosition = new Vector3(0f, 0f, 3.2f);
        }
        Cube.transform.localPosition = new Vector3(0f, 0f, -4f);
        GameMode = 0;
		if(dt.day == 0)
		{
			TutorialValue = 5;
		}
		TaskList.Remove("Fix Radio");
        camswitch.GoToPlayerCamera();
    }
}
