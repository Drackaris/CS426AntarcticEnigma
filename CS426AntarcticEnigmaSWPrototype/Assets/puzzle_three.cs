using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class puzzle_three : MonoBehaviour
{

    public Material highlightMat;
    public Material normalMat;
    public GameObject cube,cube1,cube2,cube3;
    public GameObject[] MyObjects;
    public int level = 1;
    public int counter = 0;
    public int[] Nums;




    // Start is called before the first frame update
    void Start()
    {
        MyObjects = new GameObject[4];
        MyObjects[0] = cube;
        MyObjects[1] = cube1;
        MyObjects[2] = cube2;
        MyObjects[3] = cube3;

        cube.GetComponentInChildren<Renderer>().material = normalMat;
        cube1.GetComponentInChildren<Renderer>().material = normalMat;
        cube2.GetComponentInChildren<Renderer>().material = normalMat;
        cube3.GetComponentInChildren<Renderer>().material = normalMat;

        Nums = new int[15];

        ChangeCol();
    }

    // Update is called once per frame
    void Update()
    {









    }

    public void ChangeCol()
    {
        if(level == 1)
        {
            if(counter > 5)
            {
                counter = 0;
                level = 2;
            }
            popUArr(5);
            int num = Nums[counter];
            GameObject o = MyObjects[num];
            o.GetComponentInChildren<Renderer>().material = highlightMat;

            Invoke("ChangeBack", 3f);
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

            Invoke("ChangeBack", 3f);
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

            Nums[i] = randomNumber;

        }

    }


}
