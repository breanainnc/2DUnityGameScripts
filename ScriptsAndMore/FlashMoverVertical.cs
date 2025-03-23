using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashMoverVertical : MonoBehaviour
{
    public float[] YEventPos;
    private Vector2 velocity;
    int arrayIndex = 1;
    public bool DierectionNorth;
    public GameObject[] laser;
    public int speed = 70;

    void Start()
    {
        velocity.x = speed;
        velocity.y = 0;
        if (DierectionNorth == false)
        {
            velocity.x = speed * -1;
            arrayIndex = YEventPos.Length - 1;

        }
    }

    void FixedUpdate()
    {
        transform.Translate(velocity * Time.deltaTime);


        if (DierectionNorth && transform.position.y > YEventPos[arrayIndex])
        {
            if (arrayIndex != 0 && arrayIndex != (YEventPos.Length - 1))
            {
                laserfunction();
            }
            arrayIndex++;
            if (arrayIndex == YEventPos.Length)
            {
                arrayIndex = YEventPos.Length - 1;
                DierectionNorth = false;
                velocity.x = velocity.x * -1;
            }
        }
        else if (DierectionNorth == false && transform.position.y < YEventPos[arrayIndex])
        {
            if (arrayIndex != 0 && arrayIndex != (YEventPos.Length - 1))
            {
                laserfunction();
            }
            arrayIndex--;
            if (arrayIndex == -1)
            {
                arrayIndex = 0;
                DierectionNorth = true;
                velocity.x = velocity.x * -1;
            }
        }

    }

    // Update is called once per frame
    void laserfunction()
    {
        
        if (laser[0].GetComponent<SpriteRenderer>().enabled == true)
        {
            for (int i = 0; i < 3; i++)
            {
                laser[i].GetComponent<SpriteRenderer>().enabled = false;
                laser[i].GetComponent<BoxCollider2D>().enabled = false;
                laser[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                laser[i].GetComponent<SpriteRenderer>().enabled = true;
                laser[i].GetComponent<BoxCollider2D>().enabled = true;
                laser[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        
    }
}
