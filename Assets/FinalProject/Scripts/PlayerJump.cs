using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private bool _waterCheck;
    private string _waterTag = "Water";
    public float fallForce = 2;
    private Vector2 _gravityVector;
    private Rigidbody2D _rigidbody2D;
    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.8f;
    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;
    public float jumpforce = 10;
    public bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        _gravityVector = new Vector2(0, Physics2D.gravity.y);
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_waterTag))
        {
            _waterCheck = true;
        }
    }
        private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_waterTag))
        {
            _waterCheck = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
   

        _groundCheck = Physics2D.OverlapCapsule(feetCollider.position, new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal, 0, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && (_groundCheck || _waterCheck) && canJump)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpforce);
        }
        if (_rigidbody2D.velocity.y < 0 && !_waterCheck)
        {
            _rigidbody2D.velocity += _gravityVector * fallForce * Time.deltaTime;
        }
    }

    public void setCanJump(bool boolean)
    {
        canJump = boolean;
    }

}
    