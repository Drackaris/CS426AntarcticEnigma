using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TutorialNPCMovement : MonoBehaviour
{
	public Transform Computer;
	public Transform Kitchen;
	public Transform Security;
	NavMeshAgent agent;
	private Animator anim;
	public SimpleMovement sm;

	// Start is called before the first frame update
	void Start()
	{
		anim = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
		sm = GameObject.Find("Player").GetComponent<SimpleMovement>();
	}

	// Update is called once per frame
	void Update()
	{
		
		anim.SetBool("Walk", true);

		if (sm.TaskList.Contains("Store Data In The Computer"))
		{
			agent.SetDestination(new Vector3(Computer.position.x, Computer.position.y, Computer.position.z - 3f));

		}
		else if (!sm.TaskList.Contains("Store Data In The Computer") && !sm.LookingAtCanvas)
		{
			agent.SetDestination(new Vector3(Kitchen.position.x, Kitchen.position.y, Kitchen.position.z + 3f));
		}
		else if (!sm.TaskList.Contains("Store Data In The Computer") && !sm.TaskList.Contains("Cook Food In The Kitchen") && !sm.LookingAtCanvas)
		{
			agent.SetDestination(new Vector3(Security.position.x, Security.position.y, Security.position.z + 2.5f));
		}

	}
}
