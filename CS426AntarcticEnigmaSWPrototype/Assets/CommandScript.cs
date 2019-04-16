using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CommandScript : MonoBehaviour
{
	public Text CommandList;
	public Text Attempts;
	public SimpleMovement sm;
	public List<string> StringList;
	public int NumAttempts;
    // Start is called before the first frame update
    void Start()
    {
		sm = GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleMovement>();
		StringList = sm.LevelCommands;
		NumAttempts = sm.ComputerPuzzleAttempts;
		
	}

    // Update is called once per frame
    void Update()
    {
		CommandList.text = "";
		StringList = sm.LevelCommands;
		foreach(string str in StringList)
		{
			CommandList.text += str +",";
		}
		NumAttempts = sm.ComputerPuzzleAttempts;
		Attempts.text = "Attempts: " + NumAttempts + "/3";
    }
}
