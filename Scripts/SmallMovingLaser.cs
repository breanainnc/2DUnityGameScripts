using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMovingLaser : MonoBehaviour
{
    private Vector2 velocity;
    private bool direction = true;
    public int top, bottom;
    void Start()
    {
        velocity.x = 70;
        velocity.y = 0;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(velocity * Time.deltaTime);
        
        if (direction == true && transform.position.y > top)
        {
            velocity.x = velocity.x * -1;
            direction = false;
        }
            
        else if (direction == false && transform.position.y < bottom)
        {
            
            velocity.x = velocity.x * -1;
            direction = true;
          
        }
    }
}
