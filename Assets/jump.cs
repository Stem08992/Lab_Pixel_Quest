using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    // Components
    private Rigidbody2D _rigidbody2D;
    // Forces
    public float jumpForce = 10;
    public float fallForce = 2;
    private Vector2 _gravityVector;
    // Capsule
    public float CapsuleHeight = .25f;
    public float CapsuleRadius = .08f;
    // Ground Check
    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;
        // Start is called before the first frame update
    void Start()
    {
        _gravityVector = new Vector2(0, Physics2D.gravity.y);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if player is touching the ground
        _groundCheck = Physics2D.OverlapCapsule(feetCollider.position, new Vector2(CapsuleHeight, CapsuleRadius),
            CapsuleDirection2D.Vertical, 0, groundMask);
        //checks if the player can jump 
        if (Input.GetKeyDown(KeyCode.W) && _groundCheck)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        }

        // Checks if the gravity should be getting faster
        if(_rigidbody2D.velocity.y < 0)
        {
            _rigidbody2D.velocity += _gravityVector * (fallForce * Time.deltaTime);
        }





    }
}
