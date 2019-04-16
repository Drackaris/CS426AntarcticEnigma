using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePlayerUIScript : MonoBehaviour
{
	public Day_TimeScript DT;
	public Text Time;
	float Hour;
	float Minute;
    // Start is called before the first frame update
    void Start()
    {
		DT = GameObject.Find("TimeController").GetComponent<Day_TimeScript>();
	}

    // Update is called once per frame
    void Update()
    {
		Time.text = "";
		Hour = DT.hour;
		Minute = DT.minutes;
		if (Hour < 10)
		{
			Time.text += "0" + Hour + ":" + Minute;
		}
		else
		{
			Time.text += Hour + ":" + Minute;
		}
	}
}
