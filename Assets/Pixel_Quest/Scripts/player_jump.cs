using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_jump : MonoBehaviour
{
    public Rigidbody2D rb;
    //public float jump = 10f;
    //public bool isJumping;
    public Rigidbody2D groundCheck;
    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;
    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;
    private float fallFource = 0.8f;
    private Vector2 _gravityVector;
    public float jumpForce = 6f;
    public bool _waterCheck;
    //public int DoubleJump=2;

    // Start is called before the first frame update
    void Start()
    {
        _gravityVector = new Vector2(0f,Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water") { _waterCheck = true;}

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Water") { _waterCheck = false;}
    }


    // Update is called once per frame
    void Update()
    {
        _groundCheck = Physics2D.OverlapCapsule(feetCollider.position,
            new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal, 0, groundMask);
        
        if (Input.GetKeyDown(KeyCode.Space) && (_groundCheck || _waterCheck) /*&& (DoubleJump)*/)
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        }
        
        if(rb.velocity.y < 0 && !_waterCheck)
        {
            rb.velocity += _gravityVector * (fallFource * Time.deltaTime);
        }
        
        
        
        
        /*if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }*/
    }
    /*private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }
    */
}
