using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private bool _waterCheck;

    private float CapsuleHeight = .25f;
    private float CapsuleRadius = .08f;

    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;
    private float fallForce = 1.5f;
    private Vector2 gravityVector;

    private Rigidbody2D rb;
    private float jumpForce = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityVector = new Vector2(0,Physics2D.gravity.y);
    }
    public void fall()
    {
        if(rb.velocity.y < 0 && !_waterCheck)
        {
            rb.velocity += gravityVector * (fallForce * Time.deltaTime);
        }
    }
    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (_groundCheck || _waterCheck))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Water")
        {
            _waterCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            _waterCheck = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _groundCheck = Physics2D.OverlapCapsule(feetCollider.position,
            new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal, 0, groundMask);
        fall();
        jump();
    }
}
