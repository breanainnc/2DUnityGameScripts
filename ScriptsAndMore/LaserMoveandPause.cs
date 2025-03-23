using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMoveandPause : MonoBehaviour
{
    private Vector2 velocity;
    private bool direction = false;
    public int[] eventPoints = { 2611, 2826, 2887 };
    int point = 0;
    bool pause = false;
    int counter = 0;
    public GameObject laser;
    float pos;
    void Start()
    {
        velocity.x = 0;
        velocity.y = 70;

    }


    void FixedUpdate()
    {

        transform.Translate(velocity * Time.deltaTime);
        if (direction == false && point == 0 && transform.position.x > eventPoints[0])
        {
            velocity.y = 0;
            point++;
            direction = true;
            pause = true;
        }
        else if (direction == true && point == 1 && transform.position.x < eventPoints[1])
        {
            laser.GetComponent<SpriteRenderer>().enabled = true;
            laser.GetComponent<BoxCollider2D>().enabled = true;
            laser.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            point++;
        }
        else if (direction == false && point == 1 && transform.position.x > eventPoints[1])
        {
            laser.GetComponent<SpriteRenderer>().enabled = false;
            laser.GetComponent<BoxCollider2D>().enabled = false;
            laser.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            point--;
        }
        else if (direction == true && point == 2 && transform.position.x < eventPoints[2])
        {
            
            point--;
            direction = false;
            velocity.y = velocity.y * -1;

        }

        if (pause == true)
        {
            counter++;
            if (counter > 300)
            {
                velocity.y = -70;
                counter = 0;
                pause = false;
            }
        }
    }


}

