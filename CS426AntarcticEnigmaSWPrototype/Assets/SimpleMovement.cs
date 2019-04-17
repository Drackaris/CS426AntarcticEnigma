using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{

    public float speed = 25.0f;
	public float rotationSpeed = 90;
	public float force = 700f;
    private float barSpeed = 10;
    public int PuzzlePieceDirection;
	private CameraSwitch camswitch;
	public GameObject PuzzleBlock;
	private GameObject PuzzlePiece;
    private GameObject Bar;
    private Vector3 SpawnLocation;
	public List<string> LevelCommands;
	public List<string> TaskList;
	Rigidbody rb;
	Transform t;

	public int GameMode; //0 if player controled 1 for computer 2 for kitchen....etc.....
	public bool CanGoToComputer;
    public bool CanGoToKitchen;
    public bool CanGoToTV;
    public bool CanGetTaskList;
	public int ComputerPuzzleAttempts;

    public int chances = 0;
    public int onGreen = 0;
    public bool kDone = false;
    public int inK = 0;

    public AcceptSound acceptS;
    public MissSound missS;

    public TMPro.TextMeshProUGUI canvasText;     public Canvas canvas;     public GameObject panel;      public int StartOfGame;     public int StartOfKitchen;
    public int StartOfComp;
    public int StartOfPuzzT;

    public WinSound wS;
    public LoseSound lS;

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
        PuzzlePieceDirection = 1;
		camswitch = GameObject.FindGameObjectWithTag("GameController").GetComponent<CameraSwitch>();
		PuzzlePiece = GameObject.FindGameObjectWithTag("ComputerStartTag");
        Bar = GameObject.FindGameObjectWithTag("Bar");
        SpawnLocation = new Vector3(PuzzlePiece.transform.position.x, PuzzlePiece.transform.position.y, PuzzlePiece.transform.position.z);
		LevelCommands = new List<string>();
		TaskList = new List<string>();
		ComputerPuzzleAttempts = 1;

        canvasText = canvas.GetComponentInChildren<TMPro.TextMeshProUGUI>();         StartOfGame = 1;         StartOfKitchen = 0;
        StartOfComp = 0;
        StartOfPuzzT = 0;
    }

	// Update is called once per frame
	void Update()
	{
		if (GameMode == 0)
		{
            if (StartOfGame == 1)             {                 canvasText.SetText("This is your fist day working at the Antarctic research base, your first goal is to read the task list. (Going up to it and pressing space).  " +                    "After that you should feel free to explore the base and do the tasks you are asked of. If you understand press 'c', and good luck!");                  StartOfGame = 0;                 panel.SetActive(true);             }

            if (Input.GetKey(KeyCode.C))             {                 panel.SetActive(false);                 canvasText.SetText("");             }

            if (Input.GetKey(KeyCode.W))
				rb.velocity += this.transform.forward * speed * Time.deltaTime;
			else if (Input.GetKey(KeyCode.S))
				rb.velocity -= this.transform.forward * speed * Time.deltaTime;

			if (Input.GetKey(KeyCode.D))
				rb.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
			else if (Input.GetKey(KeyCode.A))
				rb.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);

			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (CanGoToComputer)
				{
					if (TaskList.Contains("Store Data In The Computer"))
					{
						Debug.Log("Trying to switch camera.");
						camswitch.GoToComputerCamera();
						GameMode = 1;
					}
				}

                if (CanGoToKitchen)
                {
                    if (TaskList.Contains("Cook Food In The Kitchen"))
                    {
                        Debug.Log("Trying to switch camera.");
                        camswitch.GoToKitchenCamera();
                        GameMode = 2;
                    }
                }

                if (CanGoToTV)
                {
                    if (TaskList.Contains("Fix TV"))
                    {
                        Debug.Log("Trying to switch camera.");
                        camswitch.GoToPuzzleThree();
                        GameMode = 3;
                    }
                }

                if (CanGetTaskList)
				{
					if (TaskList.Count == 0)
					{
						TaskList.Add("Store Data In The Computer");
						TaskList.Add("Cook Food In The Kitchen");
                        TaskList.Add("Fix TV");
                    }
				}
            }


        }
		else if (GameMode == 1)
		{

            if (StartOfComp == 0)
            {
                canvasText.SetText("In this puzzle you will use 'A' and 'D' to move between pots. Use the space-bar to get the slider on the green, and the selected pot will stop burning. If you understand press 'c', and good luck!");
                panel.SetActive(true);
                StartOfComp = 1;
            }

            if (Input.GetKey(KeyCode.C))
            {
                panel.SetActive(false);
                canvasText.SetText("");
            }

            PuzzlePiece = GameObject.FindGameObjectWithTag("ComputerStartTag");
			if (Input.GetKeyDown(KeyCode.W))
			{
				LevelCommands.Add("F");
			
			}
			if(Input.GetKeyDown(KeyCode.A))
			{
				LevelCommands.Add("L");

			}
			if(Input.GetKeyDown(KeyCode.D))
			{
				LevelCommands.Add("R");

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
            if (StartOfKitchen == 0)             {                 canvasText.SetText("In this puzzle you will use 'A' and 'D' to move between pots. Use the space-bar to get the slider on the green, and the selected pot will stop burning. If you understand press 'c', and good luck!");                 panel.SetActive(true);                 StartOfKitchen = 1;             }              if (Input.GetKey(KeyCode.C))             {                 panel.SetActive(false);                 canvasText.SetText("");             } 
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
                        kDone = false;
                        StartOfKitchen = 0;
                        chances = 0;
                        wS.audioSource.Play(); 

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
                        lS.audioSource.Play();

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
            }
        }
        else if (GameMode == 3)
        {
            if (StartOfPuzzT == 0)
            {
                canvasText.SetText("In this puzzle you will use 'A' and 'D' to move between pots. Use the space-bar to get the slider on the green, and the selected pot will stop burning. If you understand press 'c', and good luck!");
                panel.SetActive(true);
                StartOfPuzzT = 1;
            }

            if (Input.GetKey(KeyCode.C))
            {
                panel.SetActive(false);
                canvasText.SetText("");
            }
            if (Input.GetKey(KeyCode.Escape))
            {            
                camswitch.GoToPlayerCamera();
                GameMode = 0;
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
        if (other.tag == "Task")
		{
			CanGetTaskList = true;
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

        if (other.tag == "Task")
		{
			CanGetTaskList = false;
		}
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
}
