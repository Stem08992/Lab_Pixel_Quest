using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;

    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;

    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private float fallForce = -1;
    private Vector2 gravityForce;

    void Start()
    {
        gravityForce = new Vector2(0f, Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _groundCheck = Physics2D.OverlapCapsule(
            point: feetCollider.position,
            size: new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal,
            angle: 0, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    // Simple ground check using collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
  

}   
