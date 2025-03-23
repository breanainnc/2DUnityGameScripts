using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourButtonsDoor : MonoBehaviour
{
    public GameObject ButtonSW;
    public GameObject ButtonSE;
    public GameObject ButtonNW;
    public GameObject ButtonNE;
    public GameObject Door;
    public Sprite red;
    public Sprite green;
    int count = 0;
    // Start is called before the first frame update

    public void ButtonPress(string name)
    {
        if (name == "ButtonSW")
        {
            ButtonSW.GetComponent<SpriteRenderer>().sprite = green;
            ButtonSW.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (name == "ButtonSE")
        {
            ButtonSE.GetComponent<SpriteRenderer>().sprite = green;
            ButtonSE.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (name == "ButtonNW")
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
        if (count == 4)
        {
            Door.GetComponent<SpriteRenderer>().enabled = false;
            Door.GetComponent<BoxCollider2D>().enabled = false;
        }
    }


}
