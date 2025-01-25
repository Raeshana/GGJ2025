using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] float speed;
    
    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, speed);
    }
}
