using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiningLaser : MonoBehaviour
{
    // Start is called before the first frame update
    public int speedRotate = 50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.back * speedRotate * Time.deltaTime);
    }
}
