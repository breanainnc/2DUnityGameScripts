using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    

    private Vector2 velocity;
    private Vector3 StartingPoint;
    int Stage = 0;

    public GameObject PathPoint1;
    public GameObject PathPoint2;

    private Transform pathPoint1Transform;
    private Vector3 pathPoint1Position;
    private Transform pathPoint2Transform;
    private Vector3 pathPoint2Position;
    

    // Start is called before the first frame update
    void Start()
    {
        velocity.y = 75;
        velocity.x = 0;

        StartingPoint = transform.position;

        pathPoint1Transform = PathPoint1.transform;
        pathPoint1Position = pathPoint1Transform.position;
        pathPoint2Transform = PathPoint2.transform;
        pathPoint2Position = pathPoint2Transform.position;
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 target;
        Vector3 targetPosition;
        if(Stage == 0)
        {
            target = pathPoint1Position - transform.position;
            targetPosition = pathPoint1Position;
        }
        else if(Stage == 1)
        {
            target = pathPoint2Position - transform.position;
            targetPosition = pathPoint2Position;
        }
        else
        {
            target = StartingPoint - transform.position;
            targetPosition = StartingPoint;
        }

        transform.rotation = Quaternion.LookRotation(Vector3.forward, target);
        transform.Translate(velocity * Time.deltaTime);
        
        if ((transform.position - targetPosition).sqrMagnitude < 9 )
        {
            Stage++;
            if(Stage > 2)
            {
                Stage = 0;
            }
        }

        
    }
}
