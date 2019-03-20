using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{

	public float speed = 25.0f;
	public float rotationSpeed = 90;
	public float force = 700f;
	public int PuzzlePieceDirection;
	private CameraSwitch camswitch;
	public GameObject PuzzleBlock;
	private GameObject PuzzlePiece;
	private Vector3 SpawnLocation;
	public List<string> LevelCommands;
	Rigidbody rb;
	Transform t;

	public int GameMode; //0 if player controled 1 for computer 2 for kitchen....etc.....
	public bool CanGoToComputer;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		t = GetComponent<Transform>();
		GameMode = 0;
		CanGoToComputer = false;
		PuzzlePieceDirection = 1;
		camswitch = GameObject.FindGameObjectWithTag("GameController").GetComponent<CameraSwitch>();
		PuzzlePiece = GameObject.FindGameObjectWithTag("ComputerStartTag");
	    SpawnLocation = new Vector3(PuzzlePiece.transform.position.x, PuzzlePiece.transform.position.y, PuzzlePiece.transform.position.z);
		LevelCommands = new List<string>();
	}

	// Update is called once per frame
	void Update()
	{
		if (GameMode == 0)
		{ 
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
					Debug.Log("Trying to switch camera.");
					camswitch.GoToComputerCamera();
					GameMode = 1;
				}
			}
		}
		else if (GameMode == 1)
		{
			PuzzlePiece = GameObject.FindGameObjectWithTag("ComputerStartTag");
			if (Input.GetKeyDown(KeyCode.W))
			{
				LevelCommands.Add("F");
			
			}
			if(Input.GetKeyDown(KeyCode.A))
			{
				LevelCommands.Add("RL");

			}
			if(Input.GetKeyDown(KeyCode.D))
			{
				LevelCommands.Add("RR");

			}
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				AttemptSolvePuzzle();
			}

			if(Input.GetKey(KeyCode.Escape))
			{
				camswitch.GoToPlayerCamera();
				GameMode = 0;
			}
		}
	}

	public void AttemptSolvePuzzle()
	{
		foreach (string str in LevelCommands)
		{
			StartCoroutine(WaitHalfSecond());
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
			else if(str == "RL")
			{
				PuzzlePiece.transform.Rotate(0, -90f, 0, Space.Self);
				PuzzlePieceDirection = GetRotationValue(PuzzlePiece);
			}
			else if(str == "RR")
			{
				PuzzlePiece.transform.Rotate(0, 90f, 0, Space.Self);
				PuzzlePieceDirection = GetRotationValue(PuzzlePiece);
			}
		}
		if(GameMode==1)
		{
			//ResetPuzzlePiece();
		}
		LevelCommands.Clear();
	}

	IEnumerator WaitHalfSecond()
	{
		yield return new WaitForSeconds(1f);
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
	}

	public void OnTriggerExit(Collider other)
	{
		if(other.tag == "Computer")
		{
			CanGoToComputer = false;
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
