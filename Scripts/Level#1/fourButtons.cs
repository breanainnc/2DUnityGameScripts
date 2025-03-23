using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fourButtons : MonoBehaviour
{
    public GameObject ButtonSW;
    public GameObject ButtonSE;
    public GameObject ButtonNW;
    public GameObject ButtonNE;
    public GameObject LaserSystem;
    public Sprite red;
    public Sprite green;
    public bool finalLevel;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPress(string name)
    {
        if(name == "ButtonSW")
        {
            ButtonSW.GetComponent<SpriteRenderer>().sprite = green;
            ButtonSW.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (name == "ButtonSE")
        {
            ButtonSE.GetComponent<SpriteRenderer>().sprite = green;
            ButtonSE.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (name == "ButtonNW" )
        {
            ButtonNW.GetComponent<SpriteRenderer>().sprite = green;
            ButtonNW.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (name == "ButtonNE")
        {
            ButtonNE.GetComponent<SpriteRenderer>().sprite = green;
            ButtonNE.GetComponent<BoxCollider2D>().enabled = false;
        }
        count++;
        if (count == 4 && !finalLevel)
        {
            LaserSystem.GetComponent<LaserSystem>().ChangeState();
            redButtons();
            count = 0;
        }
        else if(count == 4 && finalLevel){
            LaserSystem.GetComponent<LaserSystem2>().changeState();
            redButtons();
            count = 0;
        }
    }
    void redButtons()
    {
        ButtonSW.GetComponent<SpriteRenderer>().sprite = red;
        ButtonSW.GetComponent<BoxCollider2D>().enabled = true;
        ButtonSE.GetComponent<SpriteRenderer>().sprite = red;
        ButtonSE.GetComponent<BoxCollider2D>().enabled = true;
        ButtonNW.GetComponent<SpriteRenderer>().sprite = red;
        ButtonNW.GetComponent<BoxCollider2D>().enabled = true;
        ButtonNE.GetComponent<SpriteRenderer>().sprite = red;
        ButtonNE.GetComponent<BoxCollider2D>().enabled = true;
    }
}
