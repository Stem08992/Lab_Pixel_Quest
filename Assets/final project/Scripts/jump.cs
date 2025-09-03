using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    public float JumpForce = 10f;

    public Transform feetCollider;
    public LayerMask groundMask;

    private bool _groundCheck;
    public bool _waterCheck;

    private float fallForce = 3f;
    private Vector2 gravityForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityForce = new Vector2(0f, Physics2D.gravity.y);
    }

    void Update()
    {
        _groundCheck = Physics2D.OverlapCircle(feetCollider.position, 0.1f, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && (_groundCheck || _waterCheck))
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

        if (rb.velocity.y < 0 && !_waterCheck)
        {
            rb.velocity += gravityForce * (fallForce * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            _waterCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            _waterCheck = false;
        }
    }

    void OnDrawGizmos()
    {
        if (feetCollider != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(feetCollider.position, 0.1f);
        }
    }
}
