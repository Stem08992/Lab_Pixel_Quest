using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float FallForce = 2;
    public Vector2 GravityVector;
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float jumpForce = 10f;

    private bool waterCheck;
    private string waterTag = "Water";

    //Capsule
    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;

    //Ground Check
    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;

    void Start()
    {
        GravityVector = new Vector2(0f, Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        _groundCheck = Physics2D.OverlapCapsule(feetCollider.position,
            new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal, 0, groundMask);

        if(rb.velocity.y < 0f && !waterCheck)
        {
            rb.velocity += GravityVector * (FallForce * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && (_groundCheck || waterCheck))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            Debug.Log("In Water");
            waterCheck = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            waterCheck = false;
        }
    }
}
