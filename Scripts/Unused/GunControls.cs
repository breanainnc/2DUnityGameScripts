using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunControls : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject PlayerCenterPosition;

    //float Speed = 10;
    public GameObject bullet;
    public Vector2 bulletStartPosition;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            float yDirection = 0;
        float xDirection = 0;
        if (PlayerCenterPosition.transform.rotation.z != 0)
        {
            //Y AXIS STARTING POSITION
            if (PlayerCenterPosition.transform.rotation.z > -50 && PlayerCenterPosition.transform.rotation.z < 50)
            {
                yDirection= 1;
            }
            if (PlayerCenterPosition.transform.rotation.z > -140 && PlayerCenterPosition.transform.rotation.z < 140)
            {
                yDirection = -1;
            }
            //X AXIS STARTING POSITION
            if (PlayerCenterPosition.transform.rotation.z > 40 && PlayerCenterPosition.transform.rotation.z < 140)
            {
                xDirection = 1;
            }
            if (PlayerCenterPosition.transform.rotation.z < -140 && PlayerCenterPosition.transform.rotation.z > -40)
            {
                xDirection = -1;
            }
        }
            
            //     Position for the new object.
            bulletStartPosition.x = PlayerCenterPosition.transform.position.x + (10 * xDirection);
        bulletStartPosition.y = PlayerCenterPosition.transform.position.y + (10 * yDirection);
        // planet to travel along a path that rotates around the sun
       
            GameObject m = Instantiate(bullet) as GameObject;
            m.transform.position = bulletStartPosition;
            m.GetComponent<bullet>().velocity.x = 10 * xDirection;
            m.GetComponent<bullet>().velocity.y = 10 * xDirection;
            //m.GetComponent<bullet>().velocity.x = xDirection * 10;
            //m.GetComponent<bullet>().velocity.y = yDirection * 10;



        }

    }
}
