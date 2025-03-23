using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovementDebug : MonoBehaviour
{


    public Animator animator;

    private Vector3 rotation;
    private Vector3 velocity;

    private BoxCollider2D boxCollider;
    public GameObject Button;
    public GameObject DisaDoors;
    public GameObject BeenSeen;


    public int LEVEL;


    Vector3 pos;

    float XAxisInput = 0;
    float YAxisInput = 0;

    bool hasKey = false;
    bool canMove = true;
    public GameObject Key;

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
        if (canMove)
        {
            MovementController();
            CollisionDectecter();
        }

    }

    private void MovementController()
    {
        //Player Movement Controls
        
        //Method for arrow input
        YAxisInput = Input.GetAxisRaw("Vertical");
        XAxisInput = Input.GetAxisRaw("Horizontal");

        if (XAxisInput != 0 || YAxisInput != 0)
        {
            animator.SetInteger("Speed", 1);
            if (velocity.y < 55)
            {
                velocity.y++;
            }
            rotation.x = XAxisInput;
            rotation.y = YAxisInput;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, rotation);
            transform.Translate(velocity * Time.deltaTime);
        }
        else
        {
            animator.SetInteger("Speed", 0);
        }
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
                if (hit.name != "vision")
                {
                    velocity.y = 0;
                }
                if (hit.name == "vision" || hit.name == "laser" || hit.name == "laser (1)" || hit.name == "MidLaser" || hit.name == "FullLaser")
                {
                    Debug.Log("GameOVER!!!");
                    canMove = false;
                    if (hit.name == "vision")
                    {
                        hit.gameObject.GetComponentInParent<EnemyMovement>().enabled = false;

                        pos.x = hit.gameObject.transform.position.x + 15;
                        pos.y = hit.gameObject.transform.position.y + 15;
                        Instantiate(BeenSeen, pos, Quaternion.identity);
                    }

                    FindObjectOfType<GameManager>().GameOver();

                }
                if (hit.name == "key")
                {
                    hit.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    hit.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    hasKey = true;
                    //Destroy(Key);
                }
                if (hit.name == "LockedDoor" && hasKey == true)
                {
                    Destroy(hit.gameObject);
                    hasKey = false;
                }
                if (hit.name == "ButtonSW" || hit.name == "ButtonSE" || hit.name == "ButtonNW" || hit.name == "ButtonNE")
                {
                    if (LEVEL == 1)
                    {
                        Button.GetComponent<fourButtons>().ButtonPress(hit.name);
                    }
                    else if (LEVEL == 2)
                    {
                        Button.GetComponent<FourButtonsDoor>().ButtonPress(hit.name);
                    }
                }
                if (hit.name == "DisWallWest" || hit.name == "DisWallEast")
                {
                    DisaDoors.GetComponent<DissapearingWalls>().Appear();
                }
                if (hit.name == "Gold")
                {
                    FindObjectOfType<GameManager>().winGame();
                }
                //transform.Translate(translation: colliderDistance.pointB - colliderDistance.pointA);




            }


        }

    }


}

