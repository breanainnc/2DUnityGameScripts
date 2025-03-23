using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveUpDown : MonoBehaviour
{
    public float speed = 10.0f; // Speed of movement
    public float maxY = 30.0f; // Maximum Y position
    public float minY = -30.0f; // Minimum Y position
    private bool movingUp = true; // Initial direction

    void Update()
    {
        // Calculate the new position based on the current direction
        float newY = transform.position.y + (movingUp ? speed * Time.deltaTime : -speed * Time.deltaTime);

        // Clamp the new position to stay within the defined range
        newY = Mathf.Clamp(newY, minY, maxY);

        // Update the GameObject's position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Check if we've reached the upper or lower bounds and need to reverse direction
        if (newY >= maxY || newY <= minY)
        {
            movingUp = !movingUp; // Reverse direction
        }
    }
}