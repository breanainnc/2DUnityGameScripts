using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffCanon : MonoBehaviour
{
    
    public GameObject offbutton1;
    public GameObject offbutton2;
    public GameObject [] canons1; 
    public GameObject [] canons2;
    public Sprite red;
    public Sprite green;
    
   
     public void ButtonPress(string name)
    {

        if (name == "offbutton1")
        {
            offbutton1.GetComponent<SpriteRenderer>().sprite = green;
            offbutton1.GetComponent<BoxCollider2D>().enabled = false;
            
            for(int i = 0 ; i < canons1.Length; i++){
                canons1[i].GetComponent<canon>().enabled = false;
            }
        }
        else if (name == "offbutton2")
        {
            offbutton2.GetComponent<SpriteRenderer>().sprite = green;
            offbutton2.GetComponent<BoxCollider2D>().enabled = false;
            
            for(int i = 0 ; i < canons2.Length; i++){
                canons2[i].GetComponent<canon>().enabled = false;
            }
        }
    }
}
