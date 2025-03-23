using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSystem2 : MonoBehaviour
{
    public GameObject VerticalLaser;
    public GameObject HorizontalLaser;
    public GameObject Wall;
    public GameObject Lights;
    bool SecondState = false;

    public void startLasers(){
        VerticalLaser.GetComponent<LaserMovementVertical>().enabled = true;
        HorizontalLaser.GetComponent<LaserMovementHorziontal>().enabled = true;
        Lights.GetComponent<LightAlarm>().RedLight();
    }

    public void changeState(){

        if(!SecondState){
            VerticalLaser.GetComponent<LaserMovementVertical>().speed = 200;
            HorizontalLaser.GetComponent<LaserMovementHorziontal>().speed = 200;
            Lights.GetComponent<LightAlarm>().RedLight();
        }
        else{
            VerticalLaser.GetComponent<LaserMovementVertical>().speed = 0;
            HorizontalLaser.GetComponent<LaserMovementHorziontal>().speed = 0;
            VerticalLaser.SetActive(false);
            HorizontalLaser.SetActive(false);
            Wall.GetComponent<SpriteRenderer>().enabled = false;
            Wall.GetComponent<BoxCollider2D>().enabled = false;
            Lights.GetComponent<LightAlarm>().greenLight();

        }
        SecondState = true;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
