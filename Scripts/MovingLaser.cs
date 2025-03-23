using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLaser : MonoBehaviour
{
    public int pathSize;
    private Vector2 velocity;
    private float StartingPoint;
    // Start is called before the first frame update
    public GameObject laser;
    bool Stage1 = true;
    bool Small = false;
    void Start()
    {
        velocity.y = 75;
        velocity.x = 0;

        StartingPoint = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        transform.Translate(velocity * Time.deltaTime);

        if (transform.position.y > (StartingPoint + pathSize) || transform.position.y < StartingPoint)
        {

            velocity.y = velocity.y * -1;

        }

        if(Stage1 == true && Small == false && transform.position.y > StartingPoint + 50)
        {
            laser.GetComponent<SpriteRenderer>().enabled = false;
            laser.GetComponent<BoxCollider2D>().enabled = false;
            laser.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Small = true;
        }
        else if(Stage1 == true && Small == true && transform.position.y > StartingPoint + 100)
        {
            laser.GetComponent<SpriteRenderer>().enabled = true;
            laser.GetComponent<BoxCollider2D>().enabled = true;
            laser.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Small = false;
            Stage1 = false;
        }

        if (Stage1 == false && Small == false && transform.position.y < StartingPoint + 100)
        {
            laser.GetComponent<SpriteRenderer>().enabled = false;
            laser.GetComponent<BoxCollider2D>().enabled = false;
            laser.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Small = true;
        }
        else if (Stage1 == false && Small == true && transform.position.y < StartingPoint + 50)
        {
            laser.GetComponent<SpriteRenderer>().enabled = true;
            laser.GetComponent<BoxCollider2D>().enabled = true;
            laser.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Small = false;
            Stage1 = true;
        }

    }
        
 }

