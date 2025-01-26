using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLineMovement : MonoBehaviour
{
    public RectTransform blueHeadlines;
    public RectTransform redHeadlines;

    [Range(0f, 1f)]
    public float blueScore;
    private float previousBlueScore;
    private float leftMargin = Screen.width * 0.05f;
    private float textWidth; // Text width is 90% of desktop width

    // Start is called before the first frame update
    void Start()
    {
        blueScore = 0.5f;
        previousBlueScore = -1f;
        textWidth = Screen.width * 0.9f; // initialize text width
        UpdateHeadlines();
    }

    // Update is called once per frame
    void Update()
    {
        // Update headlines only if blueScore changes
        if (Mathf.Abs(blueScore - previousBlueScore) > Mathf.Epsilon)
        {
            UpdateHeadlines();
            previousBlueScore = blueScore;
        }
    }

    void UpdateHeadlines()
    {
        float redScore = 1f - blueScore;
        blueHeadlines.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, blueScore * textWidth);
        blueHeadlines.anchoredPosition = new Vector2(leftMargin, blueHeadlines.anchoredPosition.y);

        redHeadlines.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, redScore * textWidth);
        redHeadlines.anchoredPosition = new Vector2(leftMargin + blueHeadlines.rect.width, redHeadlines.anchoredPosition.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collides is a bubble
        if (other.CompareTag("Red") && gameObject.CompareTag("Red"))
        {
            blueScore--;
            Debug.Log("Red bubble hit RedHeadline! Decreasing blueScore. New blueScore: " + blueScore);
        }
        else if (other.CompareTag("Blue") && gameObject.CompareTag("Blue"))
        {
            blueScore++;
            Debug.Log("Blue bubble hit BlueHeadline! Increasing blueScore. New blueScore: " + blueScore);
        }

        // Optionally, destroy the bubble after it interacts with the headline
        Destroy(other.gameObject);
    }
}
