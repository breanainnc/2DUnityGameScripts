using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private SpriteRenderer SR;
    public Sprite red;
    public Sprite green;
    
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        SR = GetComponent<SpriteRenderer>();
    }

    
    public void ColorChange()
    {
        if (SR.sprite == red)
        {
            SR.sprite = green;
            
        }
        else
        {
            //SR.sprite = red;
           //isRed = true;
        }
    }
}
