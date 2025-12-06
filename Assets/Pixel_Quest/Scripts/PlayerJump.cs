using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    //Capsule
    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;

    //Ground Check
    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;


    public float jumpForce = 10;

    // Water Check
    private bool _waterCheck;
    private string _waterTag = "Water";


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update()
    {
        // Checks if player is touching the ground
        _groundCheck = Physics2D.OverlapCapsule(feetCollider.position,
            new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal, 0,
            groundMask);

        // Checks if player is trying to jump/can jump
        if (Input.GetKeyDown(KeyCode.Space) && (_groundCheck  || _waterCheck)) {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        }

        // Checks if the gravity should be faster
        if (_rigidbody2D.velocity.y < 0 && !_waterCheck) {
        }
    }
    private bool watercheck = false;
    private string Watertag = "water";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Watertag))
        {
            watercheck = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Watertag))
        {
            watercheck = false;
        }
    }
}