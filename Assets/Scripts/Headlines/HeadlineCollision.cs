using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadlineCollision : MonoBehaviour
{
    public Headlines headlineMovement;

    public int blueCounter;
    public int redCounter;

    public TMP_Text blueText;
    public TMP_Text redText;

    void Start() {
        //headlineMovement.blueScore = 0.5f;
        Debug.Log("headlineCollision started");

        blueCounter = 0;
        redCounter = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // print the tag of the object that collided with the headline
        Debug.Log(gameObject.tag + "collided with: " + other.gameObject.tag);
        
        // // Check if the object that collides is a bubble
        // if (other.CompareTag("Red") && gameObject.CompareTag("Red"))
        // {
        //     headlineMovement.blueScore--;
        //     Debug.Log("Red bubble hit RedHeadline! Decreasing blueScore. New blueScore: " + headlineMovement.blueScore);
        // }
        // else if (other.CompareTag("Blue") && gameObject.CompareTag("Blue"))
        // {
        //     headlineMovement.blueScore++;
        //     Debug.Log("Blue bubble hit BlueHeadline! Increasing blueScore. New blueScore: " + headlineMovement.blueScore);
        // }

        if (other.CompareTag("Red") && gameObject.CompareTag("Red"))
        {
            redCounter++;
            redText.text = "" + redCounter; 
            if (redCounter == 5) {
                SceneManager.LoadScene("RedWinScene", LoadSceneMode.Single);
            }
        }
        else if (other.CompareTag("Blue") && gameObject.CompareTag("Blue"))
        {
            blueCounter++;
            blueText.text = "" + blueCounter; 
            if (blueCounter == 5) {
                SceneManager.LoadScene("BlueWinScene", LoadSceneMode.Single);
            }
        }

        // Optionally, destroy the bubble after it interacts with the headline
        Destroy(other.gameObject);
    }
}
