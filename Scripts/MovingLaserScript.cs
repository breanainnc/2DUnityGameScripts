using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLaserScript : MonoBehaviour
{
    float[] YEventPos = { 1628,1653,1773,1853,1973,2058,2118 };
    private Vector2 velocity;
    int arrayIndex = 0;
    public bool direction;
    public GameObject laser;
    void Start()
    {
        velocity.y = 70;
        velocity.x = 0;
        if (direction == false)
        {
            velocity.y = -70;
        }
    }
    void FixedUpdate()
    {
        transform.Translate(velocity * Time.deltaTime);

        if (direction && transform.position.y > YEventPos[arrayIndex])
        {
            laserfunction();
            arrayIndex++;
            if (arrayIndex > 6)
            {
                arrayIndex = 6;
                direction = false;
                velocity.y = velocity.y * -1;
            }
        }
        else if (direction == false && transform.position.y < YEventPos[arrayIndex])
        {
            laserfunction();
            arrayIndex--;
            if (arrayIndex < 0)
            {
                arrayIndex = 0;
                direction = true;
                velocity.y = velocity.y * -1;
            }
        }

    }

    // Update is called once per frame
    void laserfunction()
{
    if (laser.GetComponent<SpriteRenderer>().enabled == true)
    {
        laser.GetComponent<SpriteRenderer>().enabled = false;
        laser.GetComponent<BoxCollider2D>().enabled = false;
        laser.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
        laser.GetComponent<SpriteRenderer>().enabled = true;
        laser.GetComponent<BoxCollider2D>().enabled = true;
        laser.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
}
