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
    static Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
				SetSleepVariables();
				this.transform.position = new Vector3(15.405f, 2.027f, -26.66f);
				this.transform.Rotate(90, 270, 0, Space.World);
				Sleeping = true;
                anim.SetBool("Walk", false);
            }
		}
	}

	void SetSleepVariables ()
	{
		this.GetComponent<NavMeshAgent>().enabled = false;
		this.GetComponent<Rigidbody>().isKinematic = true;
		this.GetComponent<Rigidbody>().useGravity = false;
	}

	void WakeUp()
	{
		this.GetComponent<NavMeshAgent>().enabled = true;
		this.GetComponent<Rigidbody>().isKinematic = false;
		this.GetComponent<Rigidbody>().useGravity = true;
		Sleep = false;
		Sleeping = false;
	}
    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Walk", true);
        if (DTScript.hour < 6)
		{
			Sleep = true;
			if (Sleeping == false)
			{ 
				agent.SetDestination(Bed.position);
            }
        }
		if (DTScript.hour >= 6 && DTScript.hour < 7)
		{
			if (Sleep == true)
			{
				WakeUp();
                
            }
			agent.SetDestination(new Vector3(Computer.position.x,Computer.position.y,Computer.position.z - 2.5f));
        }
		else if (DTScript.hour >= 7 && DTScript.hour < 14)
		{
			agent.SetDestination(new Vector3(Kitchen.position.x, Kitchen.position.y, Kitchen.position.z - 3f));
        }
    }
}
