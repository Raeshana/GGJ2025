using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICollisionDetector : MonoBehaviour
{
    public RectTransform RedHeadline; // Reference to your UI element
    public GameObject targetObject; // Reference to the GameObject with a collider

    // Update is called once per frame
    void Update() {
        if (IsOverlapping(RedHeadline, targetObject)) {
            Debug.Log("Collision Detected!");
        }
    }

    bool IsOverlapping(RectTransform uiRect, GameObject obj)
    {
        // Get the world-space corners of the UI element
        Vector3[] corners = new Vector3[4];
        uiRect.GetWorldCorners(corners);

        // Create a Bounds object for the UI element
        Bounds uiBounds = new Bounds(corners[0], Vector3.zero);
        for (int i = 1; i < corners.Length; i++)
        {
            uiBounds.Encapsulate(corners[i]);
        }

        // Get the Bounds of the target object's collider
        Collider objCollider = obj.GetComponent<Collider>();
        if (objCollider != null)
        {
            return uiBounds.Intersects(objCollider.bounds);
        }

        Collider2D objCollider2D = obj.GetComponent<Collider2D>();
        if (objCollider2D != null)
        {
            return uiBounds.Intersects(objCollider2D.bounds);
        }

        return false; // No collider attached
    }
}
