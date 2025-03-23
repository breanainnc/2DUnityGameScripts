using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2R4MvLaser : MonoBehaviour
{
    private Vector2 velocity;
    public bool direction = true;
    private int[] eventPoints = { 2658, 2783, 2847, 2972, 3051, 3175 };
    private int pointPos = 0;
    public GameObject laserFull;
    public GameObject laserMid;
    void Start()
    {
        velocity.y = 70;
        velocity.x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime);
        if (transform.position.y > 3200)
        {
            velocity.y = velocity.y * -1;
            
            
        }
        else if (transform.position.y < 2620)
        {

            velocity.y = velocity.y * -1;
            

        }

        if ( direction == true && transform.position.y > eventPoints[pointPos])
        {
            laserFunction(pointPos);
            pointPos++;
            
            if(pointPos > 5) { direction = false; pointPos--; }
        }
        if (direction == false && transform.position.y < eventPoints[pointPos])
        {
            laserFunction(pointPos);
            pointPos--;
            
            if(pointPos < 0) { direction = true; pointPos++; }
        }
    }

    private void laserFunction(int pointPos)
    {
        if (pointPos == 2 || pointPos == 3)
        {
            if (laserFull.GetComponent<SpriteRenderer>().enabled == true)
            {
                laserFull.GetComponent<SpriteRenderer>().enabled = false;
                laserFull.GetComponent<BoxCollider2D>().enabled = false;
                laserFull.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                laserFull.GetComponent<SpriteRenderer>().enabled = true;
                laserFull.GetComponent<BoxCollider2D>().enabled = true;
                laserFull.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
            if (laserFull.GetComponent<SpriteRenderer>().enabled == true)
            {
                laserFull.GetComponent<SpriteRenderer>().enabled = false;
                laserFull.GetComponent<BoxCollider2D>().enabled = false;
                laserFull.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                laserMid.GetComponent<SpriteRenderer>().enabled = true;
                laserMid.GetComponent<BoxCollider2D>().enabled = true;
                laserMid.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                laserFull.GetComponent<SpriteRenderer>().enabled = true;
                laserFull.GetComponent<BoxCollider2D>().enabled = true;
                laserFull.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
                laserMid.GetComponent<SpriteRenderer>().enabled = false;
                laserMid.GetComponent<BoxCollider2D>().enabled = false;
                laserMid.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
