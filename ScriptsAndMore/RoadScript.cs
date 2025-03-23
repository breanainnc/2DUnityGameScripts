using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    public GameObject[] roads = new GameObject[3];
    public GameObject[] backgrounds = new GameObject[2];
    int currentTile = 0;
    Vector3 pos;
    public GameObject player;

    int crossingPoint = 0;
    int backgroundcrossingPoint = 1734;
    int currentbackground = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.transform.position.x > crossingPoint){
            crossingPoint = crossingPoint + 852;
            float Xposition = (3 * 852);
            
            pos =  new Vector3(Xposition, 0, 0);
            roads[currentTile].transform.Translate(pos);
            
            currentTile++;
            if(currentTile == 3){currentTile = 0;}
        }

        if (player.transform.position.x > backgroundcrossingPoint){
            backgroundcrossingPoint+= 1734;
            pos = new Vector3(3468, 0, 0);
            backgrounds[currentbackground].transform.Translate(pos);
            if (currentbackground == 0){currentbackground = 1;}
            else {currentbackground = 0;}

        }
    }
}
