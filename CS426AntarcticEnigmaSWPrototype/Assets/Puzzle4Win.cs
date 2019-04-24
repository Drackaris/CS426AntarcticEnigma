using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle4Win : MonoBehaviour
{
    public SimpleMovement sm;
    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "puzzle4")
        {
            sm.EndPuzzleFour();
        }
    }
}
