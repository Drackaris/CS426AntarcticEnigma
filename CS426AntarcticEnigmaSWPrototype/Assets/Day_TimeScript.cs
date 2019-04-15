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
		day = 0;
		hour = 6;
		minutes = 0;
    }

	// Update is called once per frame
	void Update()
	{
		if (Time.time - lastChange > 30.0)
		{
			minutes++;
			if (minutes == 6)
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
