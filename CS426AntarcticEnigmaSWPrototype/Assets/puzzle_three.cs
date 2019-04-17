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

    public GameObject canva;
    public SimpleMovement s;
    public int repeatS = 1;
	bool LevelSuccess;


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
    
        

        //inp = GetComponent<InputField>();

        //ChangeCol();
    }

    // Update is called once per frame
    void Update()
    {

		if (s.GameMode == 3 && repeatS == 1)
		{
			canva.SetActive(false);	
			ChangeCol();
			repeatS = 0;
			level = 1;
		}

		if (s.GameMode != 3)
		{
			canva.SetActive(false);

			repeatS = 1;
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
            if(counter > 4)
            {
                counter = 0;

				WaitForUserInput(counter);
				if (CompareAnswers())
				{
					//level = 2;
				}
				if(!CompareAnswers())
				{
					Destroy(this.gameObject);
				}
			
               
            }
            popUArr(5);
            int num = Nums[counter];
            GameObject o = MyObjects[num];
            o.GetComponentInChildren<Renderer>().material = highlightMat;

            Invoke("ChangeBack", 2f);
            counter += 1;

        }
        else if(level == 2)
        {
            if (counter > 6)
            {
                counter = 0;
                level = 3;
            }
            popUArr(7);
            int num = Nums[counter];
            GameObject o = MyObjects[num];
            o.GetComponentInChildren<Renderer>().material = highlightMat;

            Invoke("ChangeBack", 2f);
            counter += 1;

        }
        else if(level == 3)
        {
            if (counter > 6)
            {
                counter = 0;
                level = 10;
            }
            popUArr(7);
            int num = Nums[counter];
            GameObject o = MyObjects[num];
            o.GetComponentInChildren<Renderer>().material = highlightMat;

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

        Invoke("ChangeCol", 3f);


    }

    public void popUArr(int num)
    {
        for(int i = 0; i < num; ++i)
        {
            System.Random random = new Random();
            int randomNumber = random.Next(0, 4);

			Nums.Add(randomNumber);

        }

    }


}
