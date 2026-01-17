using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playerjump : MonoBehaviour
{
    //Components
    private Rigidbody2D _rigidbody2D;

    //Forces
    public float jumpForce = 10;
    public float fallFOrce = 2;
    private Vector2 _gravityVector;

    //Capsule 
    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;

    //Ground Check
    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;

    // Water Check
    private bool _waterCheck;
    private string _waterTag = "Water";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_waterTag)) { _waterCheck = true; }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_waterTag)) { _waterCheck = false; }
    }

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
        _groundCheck = Physics2D.OverlapCapsule(point: feetCollider.position,
        size: new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal, angle: 0, groundMask);

        // Checks if player is trying to jump/ can jump
        if (Input.GetKeyDown(KeyCode.Space) && (_groundCheck || _waterCheck))
        { 
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        }
        //Checks if he Gravity chold be getting faster
        if (_rigidbody2D.velocity.y < 0 && !_waterCheck)
        {
            _rigidbody2D.velocity += _gravityVector * (fallFOrce * Time.deltaTime);
        }
    }
}
