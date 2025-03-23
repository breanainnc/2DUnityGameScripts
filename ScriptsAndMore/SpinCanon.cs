using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCanon : MonoBehaviour
{
   int Count = 0;
    bool move = false;
    bool Fire = true;
    int pointcount = 0;

    public GameObject Canonball;
    private GameObject positionObject;
    public GameObject positions;
    Vector3 pos;
     private float positionX;
    private float positionY;
    private GameObject[] positionArray;
    public GameObject Explosion;
    private Vector3 velocity;
    void Start()
    {
     
        positionArray = new GameObject[8];
        for (int i = 0; i < 8; i++){
            positionArray[i] = positions.gameObject.transform.GetChild(i).gameObject;
        }
        positionObject = positionArray[pointcount];
        positionX = positionObject.transform.position.x;
        positionY = positionObject.transform.position.y;
        velocity.y = 0;
        velocity.x = -300;
        pos.x = Canonball.transform.position.x;
        pos.y = Canonball.transform.position.y;
    }

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (move == true)
        {
            transform.RotateAround(transform.position, Vector3.forward, -1);
        }
        Count++;
        if (Count == 45)
        {
            move = false;
            Fire = true;
            velocity.x = -300;
        }
        if (Fire)
        {
            Canonball.transform.Translate(velocity * Time.deltaTime);
           
            if(Canonball.transform.position.x < (positionX + 10) && Canonball.transform.position.x > (positionX - 10)){
                if(Canonball.transform.position.y < (positionY + 10) && Canonball.transform.position.y > (positionY - 10)){
                    ExplodeNow();
                    Fire = false;
                    move = true;
                    updatePosition();
                }
            }
            
        }

    }
    // Update is called once per frame
   public void ExplodeNow(){
        Instantiate(Explosion, Canonball.transform.position, Quaternion.identity);
                Fire = false;
                velocity.y = 0;
                velocity.x = 0;
                Count = 0;
                Canonball.transform.position = new Vector3(pos.x, pos.y, 0);
    }
    public void updatePosition(){
        pointcount++;
        if (pointcount == 8){pointcount = 0;}

        positionObject = positionArray[pointcount];
        positionX = positionObject.transform.position.x;
        positionY = positionObject.transform.position.y;

    }
}
