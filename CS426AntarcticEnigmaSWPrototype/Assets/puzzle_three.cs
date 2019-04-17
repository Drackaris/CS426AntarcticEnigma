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

        canvasText = canvas.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        panel.SetActive(false);
        canvasText.SetText("");
        //inp = GetComponent<InputField>();

        //ChangeCol();
    }

    // Update is called once per frame
    void Update()
    {
        //To make sure Everything inside only happens once, at the beginning of the level
		if (s.GameMode == 3 && temp == 1)
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
        if(s.SecuritySystemArr.Count == 0 || s.SecuritySystemArr.Count < Nums.Count)
        {
            return false;
        }

        for (int i = 0; i < Nums.Count; i++)
		{
			if (Nums[i] == s.SecuritySystemArr[i])
			{

			}
			else
			{
				return false;
			}
			return true;
		}
		return false;
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
            }
            if (counter >= 4)
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

            if(counter < 4)
            {
                int num = Nums[counter];
                GameObject o = MyObjects[num-1];
                o.GetComponentInChildren<Renderer>().material = highlightMat;

            }


            Invoke("ChangeBack", 2f);
            counter += 1;

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
            if (counter >= 6)
            {
                counter = 0;

                WaitForUserInput(counter);
                if (CompareAnswers())
                {
                    canvasText.SetText("Moving onto next level!");
                    panel.SetActive(true);
                    level = 3;
                    popUArrOnce = 1;
                }
                if (!CompareAnswers())
                {
                    //Destroy(this.gameObject);
                    canvasText.SetText("Nope, clearing your input");
                    panel.SetActive(true);
                    counter = 0;
                    level = 2;
                    s.SecuritySystemArr.Clear();

                }


            }


            if (counter < 6)
            {
                int num = Nums[counter];
                GameObject o = MyObjects[num-1];
                o.GetComponentInChildren<Renderer>().material = highlightMat;

            }

            Invoke("ChangeBack", 2f);
            counter += 1;

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
                if (CompareAnswers())
                {
                    canvasText.SetText("Congratz You did it");
                    panel.SetActive(true);
                    level = 10;
                    popUArrOnce = 1;
                }
                if (!CompareAnswers())
                {
                    //Destroy(this.gameObject);
                    canvasText.SetText("Nope, clearing your input");
                    panel.SetActive(true);
                    counter = 0;
                    level = 10;
                    s.SecuritySystemArr.Clear();

                }


            }


            if (counter < 6)
            {
                int num = Nums[counter];
                GameObject o = MyObjects[num - 1];
                o.GetComponentInChildren<Renderer>().material = highlightMat;

            }

            Invoke("ChangeBack", 1f);
            counter += 1;

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
