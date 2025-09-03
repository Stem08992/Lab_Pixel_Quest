using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpManvir : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float jumpForce = 6f;
    public float fallForce = 2;
    private Vector2 gravityVector;

    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;

    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;

    private string waterTag = "Water";
    private bool waterCheck;
    void Start()
    {
        gravityVector = new Vector2(0, Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        _groundCheck = Physics2D.OverlapCapsule(feetCollider.position,
            new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal,
            0, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && (_groundCheck || waterCheck))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (rb.velocity.y < 0 && !waterCheck)
        {
            rb.velocity += gravityVector * (fallForce * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(waterTag))
        {
            waterCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(waterTag))
        {
            waterCheck = false;
        }
    }
}


