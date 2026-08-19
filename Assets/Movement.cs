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
    public Transform Sprite;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position += Vector3.right * speedvalues[(int)NormalSpeed] * Time.deltaTime;
        if (rb.linearVelocity.y<-24.2f){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -24.2f);
        }
        if (IsGrounded())
        {
            Vector3 rotation = Sprite.rotation.eulerAngles;
            rotation.z = Mathf.Round(rotation.z / 90f) * 90;
            Sprite.rotation = Quaternion.Euler(rotation);
            
            if(Input.GetMouseButton(0))
            {
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        else
        {
           Sprite.Rotate(Vector3.back, 452.4152186f * Time.deltaTime);
        }
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundChecktransform.position, Vector2.right * 1.1f + Vector2.up * groundCheckRadius, 0f, groundLayer) != null;
    }
}