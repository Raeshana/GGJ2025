using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadlineColliderMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BlueCollider; 
    public GameObject RedCollider;

    [Range(0f, 1f)]
    public float blueScore = 0.5f;
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

        // Update BlueCollider size and position
        // if (BlueCollider != null)
        // {
            BlueCollider.transform.localScale = new Vector3(blueScore * textWidth, BlueCollider.transform.localScale.y, BlueCollider.transform.localScale.z);
            BlueCollider.transform.position = new Vector3(leftMargin + (BlueCollider.transform.localScale.x / 2), BlueCollider.transform.position.y, BlueCollider.transform.position.z);
        // }

        // Update RedCollider size and position
        // if (RedCollider != null)
        // {
            RedCollider.transform.localScale = new Vector3(redScore * textWidth, RedCollider.transform.localScale.y, RedCollider.transform.localScale.z);
            RedCollider.transform.position = new Vector3(leftMargin + (BlueCollider.transform.localScale.x) + (RedCollider.transform.localScale.x / 2), RedCollider.transform.position.y, RedCollider.transform.position.z);
        // }

        // blueHeadlines.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, blueScore * textWidth);
        // blueHeadlines.anchoredPosition = new Vector2(leftMargin, blueHeadlines.anchoredPosition.y);

        // redHeadlines.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, redScore * textWidth);
        // redHeadlines.anchoredPosition = new Vector2(leftMargin + blueHeadlines.rect.width, redHeadlines.anchoredPosition.y);
    }
}
