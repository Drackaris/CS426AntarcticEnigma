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
    }

    // Update is called once per frame
    void Update()
    {

        //for(int i = 0; i < 4; ++i)
       // {
        //    GameObject o = MyObjects[i];
       //     o.GetComponentInChildren<Renderer>().material = normalMat;
       // }

        GameObject o = ChangeCol();
        if(o != null)
        {
            o.GetComponentInChildren<Renderer>().material = normalMat;
        }


    }

    public GameObject ChangeCol()
    {
        if (level == 1)
        {

            System.Random random = new Random();
            int randomNumber = random.Next(0, 4);

            GameObject o = MyObjects[randomNumber];
            o.GetComponentInChildren<Renderer>().material = highlightMat;

            return o;

        }

        return null;
    }
}
