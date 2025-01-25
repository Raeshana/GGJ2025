using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] float moveSpeed;
    [SerializeField] float RotationSpeed;

    [Header("Keybinds")]
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode right;
    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(left))
        {
            rb.velocity = new Vector2(-moveSpeed, 0f);
        }

        if (Input.GetKeyDown(right))
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
    }
}
