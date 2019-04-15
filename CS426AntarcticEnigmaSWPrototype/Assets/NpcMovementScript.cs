using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcMovementScript : MonoBehaviour
{
	public Day_TimeScript DTScript;
	public Transform Computer;
	public Transform Kitchen;
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
	}

    // Update is called once per frame
    void Update()
    {
		if (DTScript.minutes < 1)
		{
			agent.SetDestination(Computer.position);
		}
		else if (DTScript.minutes >= 2)
		{
			agent.SetDestination(Kitchen.position);
		}
    }
}
