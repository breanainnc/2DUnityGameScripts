using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMenuMovement : MonoBehaviour
{
    public GameObject[] Levels;
    public GameObject Button;
    int choice = 0;
    bool AxisIsinUse = false;
    bool Animate = false;
    Vector3 position;
    private Vector2 velocity;
    Vector3 buttonMovVar = new Vector3(0.0f, -250.0f);
    public Animator animator;
    public int world;
    public GameObject Player;
    public GameObject Dpad;
    public bool levelmenu;
    void Awake()
    {
        
    }
    private void Start()
    {
        velocity.y = 250;
        velocity.x = 0;
        if(levelmenu){
            if(world == 0){
                choice = Player.GetComponent<SavedDataManager>().ArrangeWorldLevels();
                //buttonMovVar.y = -600.0f;
                //Animate = true;
            }
            else if(world == -1){
                Player.GetComponent<SavedDataManager>().CharacterButtons();
            }
            else{
                Player.GetComponent<SavedDataManager>().ArrangeLevels(world);

                Player.GetComponent<SavedDataManager>().CheckIfoutOfLives();
                    


                choice = Player.GetComponent<SavedDataManager>().returnProgress(world);
               
                if(choice > 0){
                    //buttonMovVar.y = -600.0f;
                    //Animate = true;
                    }
            }
        }

        
    }
    void Update()
    {
        float x = CrossPlatformInputManager.GetAxis("Vertical");
        if ( x != 0)
        {
            if(AxisIsinUse == false)
            {
                AxisIsinUse = true;
                if(x > 0)
                {
                    if(Animate == false)
                        right();
                }
                else
                {
                    if (Animate == false)
                        left();
                }
            }
        }

        if(x  == 0)
        {
            AxisIsinUse = false;
        }

        if (Animate == true)
        {
            Animation();
            animator.SetInteger("Speed", 1);
            
        }
        else
        {
            animator.SetInteger("Speed", 0);
        }
    }

    void right()
    {
        if(choice != (Levels.Length - 1))
        {
            choice++;
           
            Animate = true;

            buttonMovVar.y = -600.0f;
        }
    }

    void left()
    {
        if (choice != 0)
        {
            choice--;
        
            Animate = true;

            buttonMovVar.y = 600.0f;
        }
    }
    
  
    void Animation()
    {
        Vector3 target;
        Vector3 targetPosition;
       
        target = Levels[choice].transform.position - transform.position;
        targetPosition = Levels[choice].transform.position;
        
      

        transform.rotation = Quaternion.LookRotation(Vector3.forward, target);
        transform.Translate(velocity * Time.deltaTime);

        
        Button.transform.Translate(buttonMovVar * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 5)
        {
            
            position.x = Levels[choice].transform.position.x;
            position.y = Levels[choice].transform.position.y;
            transform.position = position;
            Animate = false;
            //Button.SetActive(true);
        }
    }
    public void StartButton()
    {
        String Level = "BlueLevel#" + (++choice);
        SceneManager.LoadScene(Level, LoadSceneMode.Single);

    }




}
