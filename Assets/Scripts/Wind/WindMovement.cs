using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class WindMovement : MonoBehaviour
{
    [SerializeField] float windForce;
    [SerializeField] Transform rotationPoint;

    void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            var pos = other.transform.position - rotationPoint.position;
            // Apply force to the rigidbody in the direction of the wind
            rb.AddForce(pos * windForce);
        }

    }

}
