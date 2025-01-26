using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadlineCollision : MonoBehaviour
{
    public Headlines headlineMovement;

    void Start() {
        headlineMovement.blueScore = 0.5f;
        Debug.Log("headlineCollision started");
    }


    private void OnTriggerEnter(Collider other)
    {
        // print the tag of the object that collided with the headline
        Debug.Log(gameObject.tag + "collided with: " + other.gameObject.tag);
        
        // Check if the object that collides is a bubble
        if (other.CompareTag("Red") && gameObject.CompareTag("Red"))
        {
            headlineMovement.blueScore--;
            Debug.Log("Red bubble hit RedHeadline! Decreasing blueScore. New blueScore: " + headlineMovement.blueScore);
        }
        else if (other.CompareTag("Blue") && gameObject.CompareTag("Blue"))
        {
            headlineMovement.blueScore++;
            Debug.Log("Blue bubble hit BlueHeadline! Increasing blueScore. New blueScore: " + headlineMovement.blueScore);
        }

        // Optionally, destroy the bubble after it interacts with the headline
        Destroy(other.gameObject);
    }
}
