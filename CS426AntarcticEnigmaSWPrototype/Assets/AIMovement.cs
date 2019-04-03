using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    private float speed = 0.1f;
    public GameObject[] points;
    private int index = 1;
    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 1)
        {
            if (index == 2 || index == 3)
            {
                if (Vector3.Distance(transform.position, points[index].transform.position) > 0.2f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, points[index].transform.position, speed);
                }
                else
                {
                    transform.Rotate(0, 90, 0);
                    index += direction;
                }
            }
            else if (index == 4)
            {
                if (Vector3.Distance(transform.position, points[index].transform.position) > 0.2f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, points[index].transform.position, speed);
                }
                else
                {
                    transform.Rotate(0, 180, 0);
                    direction *= -1;
                    index += direction;
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, points[index].transform.position) > 0.2f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, points[index].transform.position, speed);
                }
                else
                {
                    transform.Rotate(0, 90, 0);
                    index += direction;
                }
            }
        }
        else
        {
            if (index == 2 || index == 1)
            {
                if (Vector3.Distance(transform.position, points[index].transform.position) > 0.2f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, points[index].transform.position, speed);
                }
                else
                {
                    transform.Rotate(0, -90, 0);
                    index += direction;
                }
            }
            else if (index == 0)
            {
                if (Vector3.Distance(transform.position, points[index].transform.position) > 0.2f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, points[index].transform.position, speed);
                }
                else
                {
                    transform.Rotate(0, 180, 0);
                    direction *= -1;
                    index += direction;
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, points[index].transform.position) > 0.2f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, points[index].transform.position, speed);
                }
                else
                {
                    transform.Rotate(0, -90, 0);
                    index += direction;
                }
            }
        }
    }
}
