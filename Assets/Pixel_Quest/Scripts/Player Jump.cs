using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
   



   
{
     public float CapsuleHeight = 0.25f;
public float CapsuleRadius = 0.08f;
    public float FallForce =2;
    public float jumpForce = 10;
    private Vector2 _gravityVector;
    
    public Transform feetcollider;
    public LayerMask groundMask;
    private bool _groundCheck;

    private bool _waterCheck;
    private string _waterTag = "Water";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(_waterTag))
        {
            _waterCheck = true; 
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_waterTag)) { _waterCheck = false; }
    }



    private Rigidbody2D _rigidbody2D;
    public float Jumpforce = 10f;
// Start is called before the first frame update
void Start()
    {
      _gravityVector = new Vector2(0, Physics2D.gravity.y);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _groundCheck = Physics2D.OverlapCapsule(feetcollider.position,
            new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D. Horizontal, 0, groundMask);
        
        if (Input.GetKeyDown(KeyCode.Space) && (_groundCheck || _waterCheck))
        {
         _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Jumpforce);
        }

        if(_rigidbody2D.velocity.y < 0 && !_waterCheck)
        {
            _rigidbody2D.velocity += _gravityVector * (FallForce * Time.deltaTime);
        }

    }
}
