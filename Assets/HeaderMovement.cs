using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeaderMovement : MonoBehaviour
{
    public RectTransform blueHeader;
    public RectTransform redHeader;

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
        UpdateHeaders();
    }

    // Update is called once per frame
    void Update()
    {
        // Update headers only if blueScore changes
        if (Mathf.Abs(blueScore - previousBlueScore) > Mathf.Epsilon)
        {
            UpdateHeaders();
            previousBlueScore = blueScore;
        }
    }

    void UpdateHeaders()
    {
        float redScore = 1f - blueScore;
        blueHeader.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, blueScore * textWidth);
        // blueHeader.anchoredPosition = new Vector2(0, blueHeader.anchoredPosition.y); // Ensure the blueHeader remains at the left edge
        blueHeader.anchorMin = new Vector2(0, blueHeader.anchorMin.y);
            blueHeader.anchorMax = new Vector2(0, blueHeader.anchorMax.y);
            blueHeader.anchoredPosition = new Vector2(leftMargin, blueHeader.anchoredPosition.y);

        redHeader.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, redScore * textWidth);
        // redHeader.anchoredPosition = new Vector2(blueHeader.anchoredPosition.x + blueHeader.rect.width, redHeader.anchoredPosition.y); // Position redHeader just to the right of blueHeader
        redHeader.anchorMin = new Vector2(0, redHeader.anchorMin.y);
            redHeader.anchorMax = new Vector2(0, redHeader.anchorMax.y);
            redHeader.anchoredPosition = new Vector2(leftMargin + blueHeader.rect.width, redHeader.anchoredPosition.y);
    }
}
