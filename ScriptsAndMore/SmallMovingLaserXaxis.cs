using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMovingLaserXaxis : MonoBehaviour
{
    private Vector2 velocity;
    public bool direction = true;
    public int left, right;
    void Start()
    {
        velocity.x = 70;
        velocity.y = 0;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(velocity * Time.deltaTime);

        if (direction == true && transform.position.x < left)
        {
            velocity.x = velocity.x * -1;
            direction = false;
        }

        else if (direction == false && transform.position.x > right)
        {

            velocity.x = velocity.x * -1;
            direction = true;

        }
    }
}
