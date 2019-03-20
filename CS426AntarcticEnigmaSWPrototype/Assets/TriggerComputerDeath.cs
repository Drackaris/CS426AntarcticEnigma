using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerComputerDeath : MonoBehaviour
{
	public SimpleMovement sm;
    // Start is called before the first frame update
    void Start()
    {
		sm = GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnTriggerEnter(Collider other)
	{
		Debug.Log("Collision with " + other);
		if(other.tag == "ComputerStartTag")
		{
			sm.ResetPuzzlePiece();
		}
	}
}
