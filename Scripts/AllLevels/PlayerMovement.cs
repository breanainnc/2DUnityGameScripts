using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{


    public Animator animator;

    private Vector3 rotation;
    private Vector3 velocity;
    private Vector3 position;
    private Vector3 goldScaler;

    private BoxCollider2D boxCollider;
    public GameObject Button;
    public GameObject DisaDoors;
    public GameObject BeenSeen;
    public GameObject Player;
   
    GameObject KeyUI;
    private bool win = false;
    private int winCounter = 0;
    
   

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
        goldScaler.x = 0.1f;
        goldScaler.y = 0.1f;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        velocity.y = 0;
        velocity.x = 0;
        KeyUI = GameObject.Find("KeyUI");
        KeyUI.SetActive(false);
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            MovementController();
            CollisionDectecter();
            
        }
        else if(win){
            WinAnimation();
        }

    }
    private void WinAnimation(){
        winCounter++;
        Debug.Log("WinAnimation working: " + winCounter);
        if(winCounter % 2 == 0){
            Key.transform.localScale += goldScaler;
        }
        if(winCounter == 50){
            win = false;
            Destroy(Key);
            Player.GetComponent<LoadCharacter>().WinCondition();
            FindObjectOfType<GameManager>().winGame();
            GetComponent<PlayerMovement>().enabled = false;
        }
        
    }
    private void MovementController()
    {
        //Player Movement Controls
        XAxisInput = CrossPlatformInputManager.GetAxis("Horizontal");
        YAxisInput = CrossPlatformInputManager.GetAxis("Vertical");
        //Method for arrow input
        //YAxisInput = Input.GetAxisRaw("Vertical");

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
                
                if (hit.name == "vision" || hit.name == "laser" || hit.name == "laser (1)" || hit.name == "MidLaser" || hit.name == "FullLaser" || hit.name == "CanonBall")
                {
                    velocity.y = 0;
                    Debug.Log("GameOVER!!!");
                    canMove = false;
                    if (hit.name == "vision")
                    {
                        if( hit.gameObject.transform.parent.name == "Enemy4")
                        {
                            
                            hit.gameObject.GetComponentInParent<Enemy4PMovement>().enabled = false;
                        }
                        else
                        {
                            hit.gameObject.GetComponentInParent<EnemyMovement>().enabled = false;
                        }
                        

                        pos.x = hit.gameObject.transform.position.x + 15;
                        pos.y = hit.gameObject.transform.position.y + 15;
                        Instantiate(BeenSeen, pos, Quaternion.identity);
                    }  
                    if (hit.name == "CanonBall")
                    {
                        pos.x = hit.transform.position.x;
                        pos.y = hit.transform.position.y;
                        
                       hit.gameObject.transform.parent.gameObject.GetComponent<canon>().ExplodeNow();
                       GetComponent<SpriteRenderer>().enabled = false;
                       transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                       boxCollider.enabled = false;
                    }  
                    Player.GetComponent<LoadCharacter>().Death();               
                    FindObjectOfType<GameManager>().GameOver();
                    
                    
                }
                

                    if (hit.name == "key")
                    {
                        hit.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        hit.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        hasKey = true;
                        KeyUI.SetActive(true);
                       // Destroy(Key);
                    }
                    if (hit.name == "LockedDoor" && hasKey == true)
                    {
                        Destroy(hit.gameObject);
                        KeyUI.SetActive(false);
                        hasKey = false;
                    }
                    if (hit.name == "ButtonSW" || hit.name == "ButtonSE" || hit.name == "ButtonNW" || hit.name == "ButtonNE")
                    {
                        if (LEVEL == 1 || LEVEL == 4)
                        {
                            Button.GetComponent<fourButtons>().ButtonPress(hit.name);
                        }
                        else if (LEVEL == 2)
                        {
                            Button.GetComponent<FourButtonsDoor>().ButtonPress(hit.name);
                        }
                        else if (LEVEL == 3)
                        {
                        Button.GetComponent<TwoButtonDoor>().ButtonPress(hit.name);
                        }
                    }

                    if(hit.name == "offbutton1" || hit.name == "offbutton2")
                    {
                        GameObject CanonButton = GameObject.Find("offbuttons");
                        CanonButton.GetComponent<TurnOffCanon>().ButtonPress(hit.name);
                    }
                    if (hit.name == "DisWallWest" || hit.name == "DisWallEast")
                    {
                        DisaDoors.GetComponent<DissapearingWalls>().Appear();
                        if(LEVEL == 4){
                            GameObject LS2 = GameObject.Find("LaserSystem2");
                            LS2.GetComponent<LaserSystem2>().startLasers();
                        }
                    }
                    if (hit.name == "Gold")
                    {
                        win = true;
                        Key = hit.gameObject;
                        canMove = false;
                        Key.GetComponent<BoxCollider2D>().enabled = false;
                        Key.GetComponent<Renderer>().sortingLayerName = "Foreground";
                        Key.GetComponent<Renderer>().sortingOrder = 2;
                        animator.SetInteger("Speed", 0);
                        
                    }
                    //transform.Translate(translation: colliderDistance.pointB - colliderDistance.pointA);




                }


            }

        }


    }


