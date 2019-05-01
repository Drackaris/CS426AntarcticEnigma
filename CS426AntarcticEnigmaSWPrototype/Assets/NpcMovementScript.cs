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
	public Transform Security;
	public Transform Radio;
	public Transform LoungeArea;
	public bool Sleep;
	private bool Sleeping;
	NavMeshAgent agent;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
		Sleeping = false;
		Sleep = false;
		DTScript = GameObject.Find("TimeController").GetComponent<Day_TimeScript>();
    }

	public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Bed")
		{
			if(Sleep == true)
			{
				SetSleepVariables();
				this.transform.position = new Vector3(15.405f, -0.5f, -26.66f);
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
		if (Sleeping)
		{
			anim.SetBool("Walk", false);
            anim.SetBool("Sleep", true);
		}
		else
		{
			anim.SetBool("Walk", true);
            anim.SetBool("Sleep", false);
        }
		if (this.tag == "BlueNPC")
		{
			if (DTScript.hour < 10)
			{
				Sleep = true;
				if (Sleeping == false)
				{
					agent.SetDestination(new Vector3(Bed.position.x, Bed.position.y, Bed.position.z));
				}
			}
			if (DTScript.hour >= 10 && DTScript.hour < 12)
			{

				agent.SetDestination(new Vector3(Security.position.x, Security.position.y, Security.position.z + 2.5f));
			}
			else if (DTScript.hour >= 14 && DTScript.hour < 16)
			{
				agent.SetDestination(new Vector3(Computer.position.x, Computer.position.y, Computer.position.z - 3f));
			}
			else if (DTScript.hour >= 18 && DTScript.hour < 20)
			{
				agent.SetDestination(new Vector3(Kitchen.position.x, Kitchen.position.y, Kitchen.position.z + 3f));
			}
			else
			{
				agent.SetDestination(new Vector3(LoungeArea.position.x, LoungeArea.position.y, LoungeArea.position.z + 3f));
			}
		}
		else if(this.tag == "GreenNPC")
		{
			if (DTScript.hour < 10)
			{
				Sleep = true;
						
			}
			if (DTScript.hour >= 11 && DTScript.hour < 13)
			{
				if(Sleeping == true)
				{
					WakeUp();
				}
				agent.SetDestination(new Vector3(Radio.position.x, Radio.position.y, Radio.position.z - 2.5f));
			}
			else if (DTScript.hour >= 16 && DTScript.hour < 18)
			{
				agent.SetDestination(new Vector3(Kitchen.position.x, Kitchen.position.y, Kitchen.position.z + 3f));
			}
			else if (DTScript.hour >= 18 && DTScript.hour < 20)
			{
				agent.SetDestination(new Vector3(Computer.position.x, Computer.position.y, Computer.position.z - 3f));
			}
			else
			{
				if (Sleep)
				{
					if (!Sleeping)
					{
						agent.SetDestination(new Vector3(Bed.position.x, Bed.position.y, Bed.position.z));
					}
				}
				else if (!Sleep)
				{
					agent.SetDestination(new Vector3(LoungeArea.position.x, LoungeArea.position.y, LoungeArea.position.z + 3f));
				}
			}

		}
		else if(this.tag == "RedNPC")
		{
			
			if (DTScript.hour >= 8 && DTScript.hour < 10)
			{
				agent.SetDestination(new Vector3(Kitchen.position.x, Kitchen.position.y, Kitchen.position.z + 2.5f));
			}
			else if (DTScript.hour >= 10 && DTScript.hour < 12)
			{
				agent.SetDestination(new Vector3(Computer.position.x, Computer.position.y, Computer.position.z + 3f));
			}
			else if (DTScript.hour == 12 && DTScript.minutes == 1)
			{
				Sleep = true;
			}
			else if(DTScript.hour == 14 && DTScript.minutes == 1)
			{
				WakeUp();
			}
			else if(DTScript.hour >= 14 && DTScript.hour < 16)
			{
				agent.SetDestination(new Vector3(Security.position.x, Security.position.y, Security.position.z - 3f));
			}
			else
			{
				if (Sleep)
				{
					agent.SetDestination(new Vector3(Bed.position.x, Bed.position.y, Bed.position.z));
				}
				else if (!Sleep)
				{
					agent.SetDestination(new Vector3(LoungeArea.position.x, LoungeArea.position.y, LoungeArea.position.z + 3f));
				}
			}
		}
	}
}
