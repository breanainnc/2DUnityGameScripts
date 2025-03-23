using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAlarm : MonoBehaviour
{
    public GameObject[] Lights = new GameObject[64];
    public bool redlight = false;
    public bool greenlight = false;
    public bool normallight = true;
    public Sprite Normal;
    public Sprite Red;
    public Sprite Green;
    int Count = 0;
    int totalCount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(redlight == true || greenlight == true)
        {
            if(redlight == true)
            {
                Count++;
                if(Count > 25)
                {
                    ChangeLight(Red);
                    totalCount = totalCount + Count;
                    Count = 0;
                }
                

            }
            if (greenlight == true)
            {
                Count++;
                if (Count > 25)
                {
                    ChangeLight(Green);
                    
                    Count = 0;
                }


            }
        }
        if(totalCount > 400)
        {
            redlight = false;
            totalCount = 0;
        }
    }
    void ChangeLight(Sprite color)
    {
        if(normallight == false) { color = Normal; }

        for (int i = 0; i < 32; i++)
        {
            Lights[i].GetComponent<SpriteRenderer>().sprite = color;
            
        }
        if (normallight == true) 
        { 
            normallight = false; 
        }
        else 
        { 
            normallight = true; 
        }
    }
    public void RedLight()
    {
        redlight = true;
    }
    public void greenLight()
    {
        greenlight = true;
    }
}
