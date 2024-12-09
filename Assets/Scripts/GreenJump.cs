using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenJump : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;  // Controls player movment 
    public float JumpForce = 1;      // Force with which the player jumps 

    public Transform feetCollsion;
    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool groundCheck = Physics2D.OverlapCapsule(feetCollsion.position, new Vector2(1, 0.08f), CapsuleDirection2D.Horizontal, 0, groundMask);


        // When player clicks space the character will jump 
        if (Input.GetKeyDown(KeyCode.W) && groundCheck) { 
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, JumpForce);
        }
    }

}
