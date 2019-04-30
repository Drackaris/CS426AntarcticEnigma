﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
using System.Diagnostics;

public class puzzle_three : MonoBehaviour
{

    public Material highlightMat;
    public Material normalMat;
    public GameObject cube,cube1,cube2,cube3;
    public GameObject[] MyObjects;
    public int level = 1;
    public int counter = 0;
	public List<int> Nums;

    public SimpleMovement s;
    public int temp = 1;
	bool LevelSuccess;
    int popUArrOnce = 1;

    public TMPro.TextMeshProUGUI canvasText;
    public TMPro.TextMeshProUGUI InGameText;
    public Canvas canvas;
    public GameObject panel;

    public List<int> Nums1;
    public List<int> Nums2;
    public List<int> Nums3;

    public CubeAudio cS;
    public CubeAudio1 cS1;
    public CubeAudio2 cS2;
    public CubeAudio3 cS3;


    public List<AudioSource> sound;

    Stopwatch stopwatch = new Stopwatch();

    // Start is called before the first frame update
    void Start()
    {
        MyObjects = new GameObject[4];
        MyObjects[0] = cube;
        MyObjects[1] = cube1;
        MyObjects[2] = cube2;
        MyObjects[3] = cube3;
		LevelSuccess = false;
        cube.GetComponentInChildren<Renderer>().material = normalMat;
        cube1.GetComponentInChildren<Renderer>().material = normalMat;
        cube2.GetComponentInChildren<Renderer>().material = normalMat;
        cube3.GetComponentInChildren<Renderer>().material = normalMat;

		Nums = new List<int>();
        Nums1 = new List<int>();
        Nums2 = new List<int>();
        Nums3 = new List<int>();

        canvasText = canvas.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        panel.SetActive(false);
        canvasText.SetText("");
        //inp = GetComponent<InputField>();

        Nums1.Add(1);
        Nums1.Add(2);
        Nums1.Add(1);
        Nums1.Add(3);

        Nums2.Add(1);
        Nums2.Add(2);
        Nums2.Add(1);
        Nums2.Add(4);
        Nums2.Add(3);
        Nums2.Add(4);

        Nums3.Add(4);
        Nums3.Add(3);
        Nums3.Add(2);
        Nums3.Add(4);
        Nums3.Add(1);
        Nums3.Add(2);

        sound.Add(cS.audioSource);
        sound.Add(cS1.audioSource);
        sound.Add(cS2.audioSource);
        sound.Add(cS3.audioSource);

        InGameText.SetText("");

        //ChangeCol();
    }

    // Update is called once per frame
    void Update()
    {
        //To make sure Everything inside only happens once, at the beginning of the level
		if (s.GameMode == 3 && temp == 1 && !s.panel.activeSelf)
		{
            ChangeCol();
			temp = 0;
			level = 1;

		}

        //So if we are no longer in the level, user-input is gone, and temp=1 again for the part above 
		if (s.GameMode != 3)
		{

            //panel.SetActive(false);
            //canvasText.SetText("");

            temp = 1;
		}

        if(level == 10 )
        {
           s.securityDone = true;
            InGameText.SetText("");
           //level = -1;
        }



    }
	

	public void WaitForUserInput(int i)
	{
        s.CanGiveInput = true;
		if(s.SecuritySystemArr.Count < i)
		{ WaitForUserInput(i); }

    }

	public bool CompareAnswers()
	{
        if(s.SecuritySystemArr.Count == 0 || s.SecuritySystemArr.Count < Nums1.Count)
        {
            return false;
        }

        for (int i = 0; i < Nums1.Count; i++)
		{
			if (Nums1[i] == s.SecuritySystemArr[i])
			{

			}
			else
			{
				return false;
			}
			//return true;
		}

		return true;
	}

    public bool CompareAnswers2()
    {
        if (s.SecuritySystemArr.Count == 0 || s.SecuritySystemArr.Count < Nums2.Count)
        {
            return false;
        }

        for (int i = 0; i < Nums2.Count; i++)
        {
            if (Nums2[i] == s.SecuritySystemArr[i])
            {

            }
            else
            {
                return false;
            }
            //return true;
        }
        return true;
    }

    public bool CompareAnswers3()
    {
        if (s.SecuritySystemArr.Count == 0 || s.SecuritySystemArr.Count < Nums3.Count)
        {
            return false;
        }

        for (int i = 0; i < Nums3.Count; i++)
        {
            if (Nums3[i] == s.SecuritySystemArr[i])
            {

            }
            else
            {
                return false;
            }
            //return true;
        }
        return true;
    }

    public void ChangeCol()
    {
        panel.SetActive(false);
        canvasText.SetText("");

        if (level == 1 && !s.puzzThree)
        {
            InGameText.SetText("Please wait till sequence finishes");
            panel.SetActive(false);
            canvasText.SetText("");
            //This makes sure the Array is populated only once.
            if (counter == 4)
            {
                InGameText.SetText("Ok, you have 10 seconds to input!");
            }

            if (counter > 4)
            {
                counter = 0;

				WaitForUserInput(counter);

                System.Threading.Thread.Sleep(7000);


                if (CompareAnswers())
				{
                    canvasText.SetText("Moving onto next level!");
                    panel.SetActive(true);
                    level = 2;
                    popUArrOnce = 1;
                    counter = 0;
                    s.puzzThreeText.SetText("");
                    s.input = "";
                }
				if(!CompareAnswers())
				{
                    //Destroy(this.gameObject);
                    canvasText.SetText("Nope, clearing your input");
                    panel.SetActive(true);
                    counter = 0;
                    level = 1;
                    s.SecuritySystemArr.Clear();
                    s.puzzThreeText.SetText("");
                    s.input = "";

                }
			
               
            }

            if (!panel.activeSelf && !s.panel.activeSelf)
            {
                if (counter < 4)
                {
                    int num = Nums1[counter];
                    GameObject o = MyObjects[num - 1];
                    o.GetComponentInChildren<Renderer>().material = highlightMat;
                    AudioSource s = sound[num - 1];
                    s.Play();
                }

                counter += 1;

            }
            else
            {
                counter = 0;
            }


            Invoke("ChangeBack", 2f);


        }
        else if(level == 2 && !s.puzzThree)
        {
            InGameText.SetText("Please wait till sequence finishes");
            panel.SetActive(false);
            canvasText.SetText("");
            if (counter == 6)
            {
                InGameText.SetText("Ok, you have 10 seconds to input!");
            }

            if (counter == 1)
            {
                s.SecuritySystemArr.Clear();
                //counter = 0;
            }
            if (counter > 6)
            {
                counter = 0;


                WaitForUserInput(counter);
                System.Threading.Thread.Sleep(7000);
                if (CompareAnswers2())
                {
                    canvasText.SetText("Moving onto next level!");
                    panel.SetActive(true);
                    level = 3;
                    popUArrOnce = 1;
                    s.puzzThreeText.SetText("");
                    s.input = "";
                }
                if (!CompareAnswers2())
                {
                    //Destroy(this.gameObject);
                    canvasText.SetText("Nope, clearing your input");
                    panel.SetActive(true);
                    counter = 0;
                    level = 2;
                    s.SecuritySystemArr.Clear();
                    s.puzzThreeText.SetText("");
                    s.input = "";

                }


            }

            if (!panel.activeSelf){

                if (counter < 6)
                {
                    int num = Nums2[counter];
                    GameObject o = MyObjects[num - 1];
                    o.GetComponentInChildren<Renderer>().material = highlightMat;
                    AudioSource s = sound[num - 1];
                    s.Play();
                }


                counter += 1;


            }
            Invoke("ChangeBack", 2f);

        }
        else if(level == 3 && !s.puzzThree)
        {
            InGameText.SetText("Please wait till sequence finishes");
            panel.SetActive(false);
            canvasText.SetText("");
            if (counter == 1)
            {
                s.SecuritySystemArr.Clear();
                //counter = 0;
            }
            if (counter == 6)
            {
                InGameText.SetText("Ok, you have 10 seconds to input!");
            }
            if (counter > 6)
            {
                counter = 0;
                InGameText.SetText("Ok, you have 10 seconds to input!");
                WaitForUserInput(counter);
                System.Threading.Thread.Sleep(7000);
                if (CompareAnswers3())
                {
                    InGameText.SetText("");
                    canvasText.SetText("Congratz You did it");
                    panel.SetActive(true);
					s.TaskList.Remove("Fix Security System");
                    level = 10;
                    popUArrOnce = 1;
                    s.puzzThreeText.SetText("");
                    s.input = "";
                }
                if (!CompareAnswers3())
                {
                    //Destroy(this.gameObject);
                    canvasText.SetText("Nope, clearing your input");
                    panel.SetActive(true);
                    counter = 0;
                    level = 3;
                    s.SecuritySystemArr.Clear();
                    s.puzzThreeText.SetText("");
                    s.input = "";

                }


            }

            if (!panel.activeSelf)
            {
                if (counter < 6)
                {
                    int num = Nums3[counter];
                    GameObject o = MyObjects[num - 1];
                    o.GetComponentInChildren<Renderer>().material = highlightMat;
                    AudioSource s = sound[num - 1];
                    s.Play();
                }

                counter += 1;

            }


            Invoke("ChangeBack", 1f);


        }
        else
        {
            level = 10;
            
        }

    }

    public void ChangeBack()
    {
        for (int i = 0; i < 4; ++i)
        {
            GameObject o = MyObjects[i];
            o.GetComponentInChildren<Renderer>().material = normalMat;
        }

        Invoke("ChangeCol", 2f);


    }



}
