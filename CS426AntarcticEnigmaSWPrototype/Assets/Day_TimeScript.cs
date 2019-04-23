using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_TimeScript : MonoBehaviour
{
	public int day;
	public float hour;
	public float minutes;

	public float lastChange;
    // Start is called before the first frame update
    void Start()
    {
		day = FigureOutDayScript();
		hour = 8;
		minutes = 0;
    }

	int FigureOutDayScript()
	{
		GameObject obj = GameObject.Find("LevelController");
		if(obj.tag == "Tutorial")
		{
			return 0;
		}
		else if (obj.tag == "Day1")
		{
			return 1;
		}
		else if(obj.tag == "Day2")
		{
			return 2;
		}
		else if (obj.tag == "Day3")
		{
			return 3;
		}
		return -999;
	}

	// Update is called once per frame
	void Update()
	{
		if (Time.time - lastChange > 2)
		{
			minutes++;
			if (minutes == 60)
			{
				minutes = 0;
				hour++;
				if (hour == 24)
				{


				}
			}
			lastChange = Time.time;
			Debug.Log(hour.ToString() + ":" + minutes.ToString());
		}
	}
}
