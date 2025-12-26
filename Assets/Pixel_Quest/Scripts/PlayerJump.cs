using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float jumpForce = 10f;
    public float fallForce;

    // Capsule
    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;

    //Ground Check
    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _groundCheck = Physics2D.OverlapCapsule(feetCollider.position, 
            new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal, 
            0, groundMask);
        
        if (Input.GetKey(KeyCode.Space) && (_groundCheck || _waterCheck))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        }
    }

    private bool _waterCheck = false;
    private string _waterTag = "Water";

    private void OnTriggerEnter2D(Collider2D collision)
    {
       //if (collision.tag == "Water") { _waterCheck = true; }
       if (collision.CompareTag(_waterTag)) { _waterCheck = true; }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_waterTag)) { _waterCheck = false; }
    }
}
