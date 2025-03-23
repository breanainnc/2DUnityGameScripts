using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2R3MvigLaser : MonoBehaviour
{
    public float[] YEventPos = { 855, 950, 1024, 1114, 1190, 1272, 1348, 1423, 1498, 1593 };
    private Vector2 velocity;
    int arrayIndex = 0;
    public bool direction;
    public GameObject laser;
    public GameObject laser2;
    public GameObject OtherLaser;
    private int range;
    void Start()
    {
        velocity.y = 70;
        velocity.x = 0;
        if(direction == false)
        {
            velocity.y = -70;
        }
        range = YEventPos.Length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(velocity * Time.deltaTime);
        OtherLaser.transform.Translate((-1 *velocity) * Time.deltaTime);

        if( direction && transform.position.y > YEventPos[arrayIndex])
        {
            arrayIndex++;
            laserfunction();
            
            if(arrayIndex > (range - 1)) 
            { 
                arrayIndex = range - 1;
                direction = false;
                velocity.y = velocity.y * -1;
            }
        }
        else if (direction == false && transform.position.y < YEventPos[arrayIndex])
        {
            arrayIndex--;
            laserfunction();
            
            if (arrayIndex < 0)
            {
                arrayIndex = 0;
                direction = true;
                velocity.y = velocity.y * -1;
            }
        }

    }

    void laserfunction()
    {
        if (laser.GetComponent<SpriteRenderer>().enabled == true)
        {
            laser.GetComponent<SpriteRenderer>().enabled = false;
            laser.GetComponent<BoxCollider2D>().enabled = false;
            laser2.GetComponent<SpriteRenderer>().enabled = false;
            laser2.GetComponent<BoxCollider2D>().enabled = false;
            laser.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            laser.GetComponent<SpriteRenderer>().enabled = true;
            laser.GetComponent<BoxCollider2D>().enabled = true;
            laser2.GetComponent<SpriteRenderer>().enabled = true;
            laser2.GetComponent<BoxCollider2D>().enabled = true;
            laser.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
