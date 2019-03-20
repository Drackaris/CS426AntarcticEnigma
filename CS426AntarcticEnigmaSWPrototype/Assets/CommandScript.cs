using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CommandScript : MonoBehaviour
{
	public Text CommandList;
	public SimpleMovement sm;
	public List<string> StringList;
    // Start is called before the first frame update
    void Start()
    {
		sm = GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleMovement>();
		StringList = sm.LevelCommands;
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
    }
}
