using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class RatCode : MonoBehaviour
{
    public float jumpForce = 500f;
    private Rigidbody2D rb;
    public Transform player;          
    public float moveSpeed = 8f;      
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Damage the player repeatedly
            Death playerHealth = collision.gameObject.GetComponent<Death>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // or whatever value
            }
        }
    }

    void Start()
    {
    
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Death"))
        {
            Debug.Log("Rat hit spike — jumping over!");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Jump up
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Move the rat towards the player
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );
        }
    }
}
