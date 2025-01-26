using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headlines : MonoBehaviour
{
    public RectTransform blueHeadlines;
    public RectTransform redHeadlines;

    // public GameObject blueCollider;
    // public GameObject redCollider;

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
        blueHeadlines.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, blueScore * textWidth);
        blueHeadlines.anchoredPosition = new Vector2(leftMargin, blueHeadlines.anchoredPosition.y);

        redHeadlines.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, redScore * textWidth);
        redHeadlines.anchoredPosition = new Vector2(leftMargin + blueHeadlines.rect.width, redHeadlines.anchoredPosition.y);

        // UpdateCollider(blueCollider, blueHeadlines);
        // UpdateCollider(redCollider, redHeadlines);
    }

    // void UpdateCollider(GameObject colliderObject, RectTransform rectTransform)
    // {
    //     // Convert RectTransform position to world position
    //     Vector3 worldPosition = rectTransform.position;

    //     // Get the BoxCollider component
    //     BoxCollider collider = colliderObject.GetComponent<BoxCollider>();

    //     if (collider != null)
    //     {
    //         // Update collider position and size
    //         colliderObject.transform.position = worldPosition;

    //         // Convert UI dimensions to world space dimensions
    //         float colliderWidth = rectTransform.rect.width * rectTransform.lossyScale.x;
    //         float colliderHeight = rectTransform.rect.height * rectTransform.lossyScale.y;

    //         collider.size = new Vector3(colliderWidth, colliderHeight, 0.1f); // Small Z-axis depth
    //         collider.center = new Vector3(colliderWidth / 2f, -colliderHeight / 2f, 0f); // Adjust to anchor from top-left
    //     }
    // }
}
