using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovementHorziontal : MonoBehaviour
{
    public float[] XEventPos;
    private Vector2 velocity;
    int arrayIndex = 1;
    public bool direction;
    public int speed = 70;
    public GameObject laser;

    private SpriteRenderer laserSpriteRenderer;
    private BoxCollider2D laserCollider;
    private SpriteRenderer childSpriteRenderer;

    void Start()
    {
        velocity.x = speed;
        velocity.y = 0;
        if (direction == false)
        {
            velocity.x = speed * -1;
            arrayIndex = XEventPos.Length - 1;

        }
        laserSpriteRenderer = laser.GetComponent<SpriteRenderer>();
        laserCollider = laser.GetComponent<BoxCollider2D>();
        childSpriteRenderer = laser.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        transform.Translate(velocity * Time.deltaTime);


        if (direction && transform.position.x > XEventPos[arrayIndex])
        {
            if (arrayIndex != 0 && arrayIndex != (XEventPos.Length - 1))
            {
                laserfunction();
            }
            arrayIndex++;
            if (arrayIndex == XEventPos.Length)
            {
                arrayIndex = XEventPos.Length - 1;
                direction = false;
                velocity.x = velocity.x * -1;
            }
        }
        else if (direction == false && transform.position.x < XEventPos[arrayIndex])
        {
            if (arrayIndex != 0 && arrayIndex != (XEventPos.Length - 1))
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
            laserSpriteRenderer.enabled = false;
            laserCollider.enabled = false;
            childSpriteRenderer.enabled = false;
        }
        else
        {
            laserSpriteRenderer.enabled = true;
            laserCollider.enabled = true;
            childSpriteRenderer.enabled = true;
        }
    }
}
