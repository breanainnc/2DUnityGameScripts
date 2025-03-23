using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearingWalls : MonoBehaviour

{
    public GameObject WallW;
    public GameObject WallE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Appear()
    {
        WallW.GetComponent<BoxCollider2D>().offset = new Vector2(0,0);
        WallE.GetComponent<BoxCollider2D>().offset = new Vector2(0,0);
        WallW.GetComponent<SpriteRenderer>().enabled = true;
        WallE.GetComponent<SpriteRenderer>().enabled = true;
    }
}
