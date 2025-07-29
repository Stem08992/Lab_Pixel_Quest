using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class playerJump : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;

    public float Jumpforce = 20f;

    // Capsule

    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;

    //Ground check

    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;
    private float fallForce = 4;
    private Vector2 gravityForce;
    public float jumpForce = 10f;

    // water

    private bool _waterCheck;
    private string _watertag = "Water";
   
        
    // Start is called before the first frame update
    void Start()
    {
      _rigidbody2D = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {    _groundCheck = Physics2D.OverlapCapsule(point:feetCollider.position, size:new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal, angle:0, groundMask);
        if (Input.GetKeyDown(KeyCode.Space) && _groundCheck)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Jumpforce);
                
        }

        if (_rigidbody2D.velocity.y < 0)
        {
            _rigidbody2D.velocity += gravityForce * (fallForce * Time.deltaTime);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_watertag)) { _waterCheck = true; }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_watertag)) { _waterCheck = false; }
    }
}


