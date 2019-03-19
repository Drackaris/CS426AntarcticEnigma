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
			GameObject PuzzlePiece = GameObject.FindGameObjectWithTag("ComputerStartTag");
			
			if(Input.GetKeyDown(KeyCode.W))
			{	
				if(PuzzlePieceDirection == 1 )
				{
					PuzzlePiece.transform.position = new Vector3(PuzzlePiece.transform.position.x, PuzzlePiece.transform.position.y, PuzzlePiece.transform.position.z + 1);
				}
				else if(PuzzlePieceDirection == 2)
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
			if(Input.GetKeyDown(KeyCode.A))
			{
				PuzzlePiece.transform.Rotate(0, -90f, 0, Space.Self);
				PuzzlePieceDirection = GetRotationValue(PuzzlePiece);
			}
			if(Input.GetKeyDown(KeyCode.D))
			{
				PuzzlePiece.transform.Rotate(0, 90f, 0, Space.Self);
				PuzzlePieceDirection = GetRotationValue(PuzzlePiece);
			}
			if(Input.GetKey(KeyCode.Escape))
			{
				camswitch.GoToPlayerCamera();
				GameMode = 0;
			}
		}
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
