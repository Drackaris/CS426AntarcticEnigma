using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcMovementScript : MonoBehaviour
{
	public Day_TimeScript DTScript;
	public Transform Computer;
	public Transform Kitchen;
	public Transform Bed;
	private bool Sleep;
	private bool Sleeping;
	NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
		agent = GetComponent<NavMeshAgent>();
		DTScript = GameObject.Find("TimeController").GetComponent<Day_TimeScript>();
    }

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "SlideDoor")
		{
			Animator animator = other.GetComponent<Animator>();
			animator.SetTrigger("DoorOpen");
		}
		if(other.tag == "Bed")
		{
			if(Sleep == true)
			{
				this.GetComponent<NavMeshAgent>().enabled = false;
				this.GetComponent<Rigidbody>().isKinematic = true;
				this.GetComponent<Rigidbody>().useGravity = false;
				this.transform.position = new Vector3(15.405f, 2.027f, -26.66f);
				this.transform.Rotate(90, 270, 0, Space.World);
				Sleeping = true;
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
		if (DTScript.minutes == 0)
		{
			Sleep = true;
			if (Sleeping == false)
			{ 
				agent.SetDestination(Bed.position);
			}
		}
		if (DTScript.minutes >= 1 &&  DTScript.minutes < 4)
		{
			Sleep = false;
			Sleeping = false;
			this.GetComponent<NavMeshAgent>().enabled = true;
			this.GetComponent<Rigidbody>().isKinematic = false;
			this.GetComponent<Rigidbody>().useGravity = true;
			agent.SetDestination(new Vector3(Computer.position.x,Computer.position.y,Computer.position.z - 2f));
		}
		else if (DTScript.minutes >= 3)
		{
			agent.SetDestination(new Vector3(Kitchen.position.x, Kitchen.position.y, Kitchen.position.z - 2f));
		}
    }
}
