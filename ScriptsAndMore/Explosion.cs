using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private int count = 0;
    private int AniCount = 1;
    Vector3 ScaleIncrease;
    // Start is called before the first frame update
    void Start()
    {
        ScaleIncrease.x = 0.1f;
        ScaleIncrease.y = 0.1f;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if(count % 2 == 0){
            transform.localScale +=  ScaleIncrease;
            AniCount++;
        }
        if(AniCount == 11){
                Destroy(this.gameObject);
            }
    }
}
