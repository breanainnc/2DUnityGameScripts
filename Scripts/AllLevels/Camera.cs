using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public bool driveCamera = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(driveCamera == false){
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
        }
        else {
            transform.position = new Vector3(player.position.x + offset.x, 40 + offset.y, offset.z);
        }
    }
}
