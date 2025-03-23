using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoButtonDoor : MonoBehaviour
{
    public GameObject ButtonNW;
    public GameObject ButtonNE;
    public GameObject Door;
    public GameObject Door2;
    public Sprite red;
    public Sprite green;
    int count = 0;
    // Start is called before the first frame update

    public void ButtonPress(string name)
    {

        if (name == "ButtonNW")
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
        if (count == 2)
        {
            Door.GetComponent<SpriteRenderer>().enabled = false;
            Door.GetComponent<BoxCollider2D>().enabled = false;
            Door2.GetComponent<SpriteRenderer>().enabled = false;
            Door2.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
