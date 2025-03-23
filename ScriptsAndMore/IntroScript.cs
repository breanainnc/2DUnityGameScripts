using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public GameObject[] Levels;
    int choice = 0;
    private Vector2 velocity;
    Vector3 position;
    Vector3 target;
    Vector3 targetPosition;
    public GameObject Begin;
    public GameObject Finish;
    bool First = true;
   
    void Start()
    {
        velocity.y = 140;
        velocity.x = 0;
        position.x = Levels[1].transform.position.x;
        position.y = Levels[1].transform.position.y;
        transform.position = position;
        target = Levels[choice].transform.position - transform.position;
        targetPosition = Levels[choice].transform.position;
    }
    void Update()
    {
        
        transform.rotation = Quaternion.LookRotation(Vector3.forward, target);
        transform.Translate(velocity * Time.deltaTime);

        
        

        if (Vector3.Distance(transform.position, targetPosition) < 5 )
        {
            
            if(choice == 0) choice = 1;
            else choice = 0;
            target = Levels[choice].transform.position - transform.position;
            targetPosition = Levels[choice].transform.position;
            if(First)
            {
                Begin.SetActive(false);
                Finish.SetActive(true);
            }
            
        }
        
    }
}
