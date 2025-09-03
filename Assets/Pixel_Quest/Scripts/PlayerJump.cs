using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public Transform feet;
    public float jumpForce ;
    public float capsuleHeight;
    public float capsuleWidth;
    public LayerMask ground;
    private bool _groundCheck;
    private Vector2 _gravityVector;
    public float fallForce;
    private bool _waterCheck;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _gravityVector = new Vector2(0, Physics2D.gravity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")&& _groundCheck || _waterCheck)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        }

        _groundCheck = Physics2D.OverlapCapsule(feet.position,
            new Vector2(capsuleHeight, capsuleWidth), CapsuleDirection2D.Horizontal, 0, ground);

        if (_rigidbody2D.velocity.y < 0 && !_waterCheck)
        {
            _rigidbody2D.velocity += _gravityVector * (fallForce * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            _waterCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            _waterCheck = false;
        }
    }

}
