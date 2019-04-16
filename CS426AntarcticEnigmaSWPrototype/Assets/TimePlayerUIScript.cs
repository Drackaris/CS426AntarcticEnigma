using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePlayerUIScript : MonoBehaviour
{
	public Day_TimeScript DT;
	public Text Time;
	public Text Tasks;
	public SimpleMovement SM;
	public List<string> TaskList;
	float Hour;
	float Minute;
    // Start is called before the first frame update
    void Start()
    {
		DT = GameObject.Find("TimeController").GetComponent<Day_TimeScript>();
		SM = GameObject.Find("Player").GetComponent<SimpleMovement>();
		TaskList = SM.TaskList;
	}

    // Update is called once per frame
    void Update()
    {
		Time.text = "";
		Tasks.text = "";
		Hour = DT.hour;
		Minute = DT.minutes;
		TaskList = SM.TaskList;
		if (Hour < 10)
		{
			Time.text += "0" + Hour + ":" + Minute;
		}
		else
		{
			Time.text += Hour + ":" + Minute;
		}
		foreach(string s in TaskList)
		{
			Tasks.text += s + "\n";
		}
	}
}
