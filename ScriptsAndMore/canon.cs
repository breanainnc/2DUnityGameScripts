using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon : MonoBehaviour
{
    private GameObject Canonball;
    private GameObject positionObject;
    public GameObject Explosion;
    private Vector3 velocity;
    Vector3 pos;
    public int speed = 100;
    public int waitTime = 500;
    public int waitStart = 0;
    private float positionX;
    private float positionY;
    private int count = 0;
    private bool Fire = false;
    private bool waitOver = false;
    public bool Vertical = false;
    

    // Start is called before the first frame update
    void Start()
    {
        Canonball = this.gameObject.transform.GetChild(0).gameObject;
        positionObject = this.gameObject.transform.GetChild(1).gameObject;
        positionX = positionObject.transform.position.x;   
        positionY = positionObject.transform.position.y;  
        velocity.y = 0;
        velocity.x = 0;
        pos.x = Canonball.transform.position.x;
        pos.y = Canonball.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (waitOver == false){
            wait();
        }
        if(waitOver){

            if (!Fire){
                count++;
                if(count == waitTime){
                    Fire = true;
                    velocity.y = 0;
                    velocity.x = speed * -1;
                    count = 0;
                }
            }
        else{
            count++;
            Canonball.transform.Translate(velocity * Time.deltaTime);
            if(!Vertical){
                if(Canonball.transform.position.x < (positionX + 5) && Canonball.transform.position.x > (positionX - 5)){
                    ExplodeNow();
                }
            }
            else{
                if(Canonball.transform.position.y < (positionY + 5) && Canonball.transform.position.y > (positionY - 5)){
                    ExplodeNow();
                }
            }
        }
    }
    }   
    

    void wait(){
        if(count == waitStart){
            waitOver = true;
        }
            count++;
        
    }

    public void ExplodeNow(){
        Instantiate(Explosion, Canonball.transform.position, Quaternion.identity);
                Fire = false;
                velocity.y = 0;
                velocity.x = 0;
                count = 0;
                Canonball.transform.position = new Vector3(pos.x, pos.y, 0);
    }
}
