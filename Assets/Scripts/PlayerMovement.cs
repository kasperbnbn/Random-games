using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float jumpForce = 5f; // Force applied for jumping
    public int maxJumps = 2; // Maximum number of jumps allowed

    private Rigidbody2D rb;
    private bool isGrounded; // Flag indicating if the player is grounded
    private int jumpsRemaining; // Number of jumps remaining

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
    }

    private void Update()
    {
        // Get input for horizontal movement
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Calculate movement vector
        Vector2 movement = new Vector2(moveHorizontal, 0f) * moveSpeed;

        // Apply movement to the rigidbody
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

        // Check if the player is grounded
        isGrounded = IsGrounded();

        // Check for jump input and perform jump
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Jump();
            }
            else if (jumpsRemaining > 0)
            {
                Jump();
                jumpsRemaining--;
            }
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private bool IsGrounded()
    {
        // Perform an overlap check to detect if the player is touching the ground
        float checkRadius = 0.1f;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, checkRadius);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject && colliders[i].gameObject.CompareTag("Obstacle"))
            {
                return true;
            }
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset jumps when colliding with an object tagged as "Obstacle" or "Ground"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            jumpsRemaining = maxJumps;
        }
    }
}
