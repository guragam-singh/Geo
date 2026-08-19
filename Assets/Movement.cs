using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Speeds
{
    slow = 0,
    normal = 1,
    fast = 2,
    faster = 3,
    fastest = 4
}

public class Movement : MonoBehaviour
{
    public Speeds NormalSpeed;
    float[] speedvalues = { 8.6f, 10.4f, 12.96f, 15.6f, 19.27f };
    public Transform groundChecktransform;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public float jumpForce = 26.8561f;

    Rigidbody2D rb;
    bool wasGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position += Vector3.right * speedvalues[(int)NormalSpeed] * Time.deltaTime;

        bool grounded = IsGrounded();

        // Only jump on the frame we LAND, not every frame we're grounded
        if (grounded && !wasGrounded)
        {
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        wasGrounded = grounded;
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundChecktransform.position, groundCheckRadius, groundLayer) != null;
    }
}