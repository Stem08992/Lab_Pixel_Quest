using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HHQPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private HHQPlayerPickup Pickup;
    private Rigidbody2D rb;
    private void Start()
    {
        Pickup = GetComponent<HHQPlayerPickup>();
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        
      float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (horizontalInput * moveSpeed, rb.velocity.y);
        if (horizontalInput  < 0)
        {
         Pickup.facingLeft = true;
        }
        if (horizontalInput > 0) 
        { 
            Pickup.facingLeft = false; 
        }
    }
}