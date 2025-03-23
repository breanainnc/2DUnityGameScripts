using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSystem : MonoBehaviour
{
    public GameObject[] Vertical = new GameObject[5];
    public GameObject[] Horizontal = new GameObject[5];
    public GameObject Wall;
    public GameObject Lights;
    int Stage = 2;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void ChangeState()
    {
        Stage++;
        if(Stage == 2)
        {
            Lights.GetComponent<LightAlarm>().RedLight();
            for (int i = 0; i < 5; i++)
            {
               
                Vertical[i].GetComponent<laserFunction>().enabled = true;
                Horizontal[i].GetComponent<laserFunction>().Dissapear();
                Horizontal[i].GetComponent<laserFunction>().enabled = false;

                
            }
        }
        if(Stage == 3)
        {
            Lights.GetComponent<LightAlarm>().RedLight();
            for (int i = 0; i < 5; i++)
            {
                Vertical[i].GetComponent<laserFunction>().enabled = true;
            }
        }
        if (Stage == 4)
        {
            Lights.GetComponent<LightAlarm>().greenLight();
            for (int i = 0; i < 5; i++)
            {
                Vertical[i].GetComponent<laserFunction>().Dissapear();
                Vertical[i].GetComponent<laserFunction>().enabled = false;
                Horizontal[i].GetComponent<laserFunction>().Dissapear();
                Horizontal[i].GetComponent<laserFunction>().enabled = false;
                Wall.GetComponent<SpriteRenderer>().enabled = false;
                Wall.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}

