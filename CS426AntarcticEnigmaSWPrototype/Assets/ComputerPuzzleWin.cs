using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPuzzleWin : MonoBehaviour
{
	public CameraSwitch cs;
	public SimpleMovement sm;
    // Start is called before the first frame update
    void Start()
    {
		cs = GameObject.FindGameObjectWithTag("GameController").GetComponent<CameraSwitch>();
		sm = GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "ComputerStartTag")
		{
			cs.GoToPlayerCamera();
		    sm.TaskList.Remove("Store Data In The Computer");
			sm.GameMode = 0;
		}
	}
}
