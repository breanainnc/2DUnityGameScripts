using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Vector3 velocity;
    public float speed = 40;
    

    private BoxCollider2D boxCollider;

    private void Awake()

    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
        //CollisionDectecter();
    }

    private void CollisionDectecter()
    {
        //checks for collisions
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);

        foreach (Collider2D hit in hits)
        {
          
            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);

            if (colliderDistance.isOverlapped)
            {
                Destroy(gameObject);
  
            }
        }
    }

}
