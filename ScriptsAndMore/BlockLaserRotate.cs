using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLaserRotate : MonoBehaviour
{
    int Count = 0;
    bool move = true;
    public GameObject[] Lasers;
    int LaserCounter = 1;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (move == true)
        {
            transform.RotateAround(transform.position, Vector3.forward, 1);
        }
        Count++;
        if (Count == 90)
        {
            UpdateLaser();
        }
        if (Count == 280)
        {
            UpdateLaser();
            Count = 0;
        }

    }

    private void UpdateLaser()
    {
        if (move == true)
        {
            move = false;
            Lasers[LaserCounter].GetComponent<SpriteRenderer>().enabled = true;
            Lasers[LaserCounter].GetComponent<BoxCollider2D>().enabled = true;
            Lasers[LaserCounter].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else 
        {
            move = true;
            Lasers[LaserCounter].GetComponent<SpriteRenderer>().enabled = false;
            Lasers[LaserCounter].GetComponent<BoxCollider2D>().enabled = false;
            Lasers[LaserCounter].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            LaserCounter++;
            if (LaserCounter == 4)
            {
                LaserCounter = 0;
            }
        }
    }
}
