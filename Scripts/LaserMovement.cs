using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public float[] YEventPos;
    private Vector2 velocity;
    int arrayIndex = 1;
    public bool direction;
    public GameObject laser;
    public int speed = 70;

    void Start()
    {
        velocity.y = speed;
        velocity.x = 0;
        if (direction == false)
        {
            velocity.y = speed * -1;
            arrayIndex = YEventPos.Length - 1;

        }
    }
    void FixedUpdate()
    {
        transform.Translate(velocity * Time.deltaTime);


        if (direction && transform.position.y > YEventPos[arrayIndex])
        {
            if (arrayIndex != 0 && arrayIndex != (YEventPos.Length - 1))
            {
                laserfunction();
            }
            arrayIndex++;
            if (arrayIndex == YEventPos.Length)
            {
                arrayIndex = YEventPos.Length - 1;
                direction = false;
                velocity.y = velocity.y * -1;
            }
        }
        else if (direction == false && transform.position.y < YEventPos[arrayIndex])
        {
            if (arrayIndex != 0 && arrayIndex != (YEventPos.Length - 1))
            {
                laserfunction();
            }
            arrayIndex--;
            if (arrayIndex == -1)
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
