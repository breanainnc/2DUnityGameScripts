using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovementVertical : MonoBehaviour
{
    public float[] YEventPos;
    private Vector2 velocity;
    int arrayIndex = 1;
    public bool direction;
    public int speed = 70;
    public GameObject laser;

    void Start()
    {
        velocity.x = speed;
        velocity.y = 0;
        if (direction == false)
        {
            velocity.x = speed * -1;
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
                velocity.x = velocity.x * -1;
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
                velocity.x = velocity.x * -1;
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
