using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerDriveMovement : MonoBehaviour
{
    public Animator animator;
    
    public int finish;
    private Vector3 rotation;
    private Vector3 velocity;
    private BoxCollider2D boxCollider;
    float YAxisInput = 0;
    bool gameOngoing = true;
    public GameObject Player;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        velocity.y = 0;
        velocity.x = 0;
        
    }

    // Update is called once per frame
     void FixedUpdate()
    {
        if (gameOngoing)
        {
            MovementController();
            CollisionDectecter();
            
        }
        if (transform.position.x > finish)
        {
            Player.GetComponent<LoadCharacter>().WinCondition();
            FindObjectOfType<GameManager>().winGame();
                
        }
    }

        private void MovementController()
    {
        //Player Movement Controls
        
        YAxisInput = CrossPlatformInputManager.GetAxis("Vertical");
       

        
            animator.SetInteger("Speed", 1);
            if (velocity.y < 200)
            {
                velocity.y++;
            }
            rotation.x = 1;

            if(YAxisInput != 0)
            {
                if( YAxisInput == 1 ){ rotation.y = 1; velocity.y = velocity.y + 2;}
                else if (YAxisInput == -1){ rotation.y = -1; velocity.y = velocity.y + 2;}
            }
            else{rotation.y = 0; velocity.y = 200;}

            if(transform.position.y < -60 ){
                if (rotation.y == -1){rotation.y = 0;}
            }
            if(transform.position.y > 145){
                if (rotation.y == 1){rotation.y = 0;}
            }
            transform.rotation = Quaternion.LookRotation(Vector3.forward, rotation);
            transform.Translate(velocity * Time.deltaTime);
        
        
            
        
    }

      private void CollisionDectecter()
    {
        //checks for collisions
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);


        foreach (Collider2D hit in hits)
        {
            if (hit == boxCollider)
                continue;
            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);
            if (colliderDistance.isOverlapped)
            { 
                 if (hit.tag == "obsticle")
                {
                    velocity.y = 0;
                    Player.GetComponent<LoadCharacter>().Death();
                    FindObjectOfType<GameManager>().GameOver();
                    gameOngoing = false;
                }
                
                transform.Translate(translation: colliderDistance.pointB - colliderDistance.pointA);
            }
        }
    }
}
        

     



