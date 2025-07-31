using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;

    // Forces
    public float JumpForce = 10f;
    public float FallForce = 5;
    private Vector2 GravityVector;

    // Capsule
    public float CapsuleHeight = 0.25f;
        public float CapsuleRadius = 0.08f;

    // Ground Check
    public Transform FeetCollider;
    public LayerMask GroundMask;
    private bool GroundCheck;

    // Water Check
    private bool WaterCheck;
    private string WaterTag = "Water";



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     // Checks if player is touching ground
        GroundCheck = Physics2D.OverlapCapsule(FeetCollider.position, new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal, 0, GroundMask);

     // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && (GroundCheck || WaterCheck))
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

     // Falling
        if (rb.velocity.x < 0 && ! WaterCheck)
        {
            rb.velocity += GravityVector * (FallForce * Time.deltaTime);
        }
    }

     //Water Check
        private void OnTriggerEnter2D(Collider2D collision)
         {
        if (collision.CompareTag(WaterTag)) { WaterCheck = true; }
         }
    // If Left Water
       private void OnTriggerExit2D(Collider2D collision)
        {
        if (collision.CompareTag(WaterTag)) { WaterCheck = false; }
        }
}

