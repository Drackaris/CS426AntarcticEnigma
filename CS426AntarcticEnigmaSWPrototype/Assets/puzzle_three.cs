using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

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
    public Canvas canvas;
    public GameObject panel;

    public List<int> Nums1;
    public List<int> Nums2;
    public List<int> Nums3;

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
			

			temp = 1;
		}

        if(level == 10)
        {
            s.securityDone = true;
            level = 1;
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
    
        if (level == 1)
        {
            panel.SetActive(false);
            canvasText.SetText("");
            //This makes sure the Array is populated only once.
            if (popUArrOnce == 1)
            {
                popUArr(4);
                popUArrOnce = 0;
                counter = 0;
            }
            if (counter > 4)
            {
                counter = 0;

				WaitForUserInput(counter);
				if (CompareAnswers())
				{
                    canvasText.SetText("Moving onto next level!");
                    panel.SetActive(true);
                    level = 2;
                    popUArrOnce = 1;
                    counter = 0;
                }
				if(!CompareAnswers())
				{
                    //Destroy(this.gameObject);
                    canvasText.SetText("Nope, clearing your input");
                    panel.SetActive(true);
                    counter = 0;
                    level = 1;
                    s.SecuritySystemArr.Clear();

                }
			
               
            }

            if (!panel.activeSelf && !s.panel.activeSelf)
            {
                if (counter < 4)
                {
                    int num = Nums1[counter];
                    GameObject o = MyObjects[num - 1];
                    o.GetComponentInChildren<Renderer>().material = highlightMat;

                }

                counter += 1;

            }
            else
            {
                counter = 0;
            }


            Invoke("ChangeBack", 2f);


        }
        else if(level == 2)
        {
            panel.SetActive(false);
            canvasText.SetText("");
            if (popUArrOnce == 1)
            {
                s.SecuritySystemArr.Clear();
                Nums.Clear();
                popUArr(6);
                popUArrOnce = 0;
                counter = 0;
            }
            if (counter > 6)
            {
                counter = 0;

                WaitForUserInput(counter);
                if (CompareAnswers2())
                {
                    canvasText.SetText("Moving onto next level!");
                    panel.SetActive(true);
                    level = 3;
                    popUArrOnce = 1;
                }
                if (!CompareAnswers2())
                {
                    //Destroy(this.gameObject);
                    canvasText.SetText("Nope, clearing your input");
                    panel.SetActive(true);
                    counter = 0;
                    level = 2;
                    s.SecuritySystemArr.Clear();

                }


            }

            if (!panel.activeSelf){

                if (counter < 6)
                {
                    int num = Nums2[counter];
                    GameObject o = MyObjects[num - 1];
                    o.GetComponentInChildren<Renderer>().material = highlightMat;

                }


                counter += 1;


            }
            Invoke("ChangeBack", 2f);

        }
        else if(level == 3)
        {
            panel.SetActive(false);
            canvasText.SetText("");
            if (popUArrOnce == 1)
            {
                s.SecuritySystemArr.Clear();
                Nums.Clear();
                popUArr(6);
                popUArrOnce = 0;
                counter = 0;
            }
            if (counter > 6)
            {
                counter = 0;

                WaitForUserInput(counter);
                if (CompareAnswers3())
                {
                    canvasText.SetText("Congratz You did it");
                    panel.SetActive(true);
                    level = 10;
                    popUArrOnce = 1;
                }
                if (!CompareAnswers3())
                {
                    //Destroy(this.gameObject);
                    canvasText.SetText("Nope, clearing your input");
                    panel.SetActive(true);
                    counter = 0;
                    level = 3;
                    s.SecuritySystemArr.Clear();

                }


            }

            if (!panel.activeSelf)
            {
                if (counter < 6)
                {
                    int num = Nums3[counter];
                    GameObject o = MyObjects[num - 1];
                    o.GetComponentInChildren<Renderer>().material = highlightMat;

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

    public void popUArr(int num)
    {
        for(int i = 0; i < num; ++i)
        {
            System.Random random = new Random();
            int randomNumber = random.Next(1, 4);

			Nums.Add(randomNumber);

        }

    }


}
