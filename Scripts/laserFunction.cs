using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserFunction : MonoBehaviour
{
    BoxCollider2D boxcollider;
    SpriteRenderer spriteRenderer;
    SpriteRenderer childSprite;
    int Count = 0;
    void Start()
    {
        boxcollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        childSprite = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Count++;
        if (Count == 140)
        {
            UpdateLaser();
        }
        if (Count == 280)
        {
            UpdateLaser();
            Count = 0;
        }
    }

    void UpdateLaser()
    {
        if(boxcollider.enabled == true)
        {
            boxcollider.enabled = false;
            spriteRenderer.enabled = false;
            childSprite.enabled = false;
        }
        else
        {
            boxcollider.enabled = true;
           spriteRenderer.enabled = true;
           childSprite.enabled = true;
        }
    }

    public void Dissapear()
    {
        boxcollider.enabled = false;
        spriteRenderer.enabled = false;
        childSprite.enabled = false;
    }
}
