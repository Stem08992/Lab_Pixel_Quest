using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public float jumpForce = 5f;
    public int maxJumps = 2;

    private Rigidbody2D rb;
    private int jumpCount;
    private bool isGrounded;
    public Rigidbody2D groundCheck;
    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;
    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;
    private float fallFource = 0.8f;
    private Vector2 _gravityVector;
    public bool _waterCheck;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 0;
    }

    void Update()
    {
        /*_groundCheck = Physics2D.OverlapCapsule(feetCollider.position,
            new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal, 0, groundMask);

        if (_groundCheck)
                {
                    jumpCount=0;
                }*/
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
             // Reset Y velocity
            jumpCount++;
            
        }
        if (jumpCount >= maxJumps)
        {
            jumpCount = 0;
        }
        if (rb.velocity.y < 0 && !_waterCheck)
        {
            rb.velocity += _gravityVector * (fallFource * Time.deltaTime);
        }
        
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        // Check if landed on something
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            jumpCount = 0;
        }

    }*/

    private void OnCollisionExit(Collision collision)
    {
        // Optional: mark as not grounded when leaving the ground
        isGrounded = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water") { _waterCheck = true; }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Water") { _waterCheck = false; }
    }
}