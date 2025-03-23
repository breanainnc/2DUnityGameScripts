using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2R4MvLasrLeft : MonoBehaviour
{
    private Vector2 velocity;
    private bool direction = true;
    private int[] eventPoints = { 2611, 2826, 2887};
    int point = 1;
    bool pause = false;
    int counter = 0;
    public GameObject laser;
    void Start()
    {
        velocity.x = 0;
        velocity.y = 70;

    }

    
    void FixedUpdate()
    {
        transform.Translate(velocity * Time.deltaTime);
        if (direction == false && point == 0 && transform.position.y < eventPoints[0])
        {
            velocity.y = velocity.y * -1;
            point++;
            direction = true;
        }
        else if(direction == true && point == 1 && transform.position.y > eventPoints[1])
        {
            laser.GetComponent<SpriteRenderer>().enabled = true;
            laser.GetComponent<BoxCollider2D>().enabled = true;
            laser.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            point++;
        }
        else if (direction == false && point == 1 && transform.position.y < eventPoints[1])
        {
            laser.GetComponent<SpriteRenderer>().enabled = false;
            laser.GetComponent<BoxCollider2D>().enabled = false;
            laser.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            point--;
        }
        else if(direction == true && point == 2 && transform.position.y > eventPoints[2])
        {
            velocity.y = 0;
            point--;
            direction = false;
            pause = true;
            
        }

        if(pause == true)
        {
            counter++;
            if(counter > 300)
            {
                velocity.y = -70;
                counter = 0;
                pause = false;
            }
        }
    }

    
}
