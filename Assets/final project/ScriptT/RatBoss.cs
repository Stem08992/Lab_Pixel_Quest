using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatBoss : MonoBehaviour
{
    public int maxHealth = 100;
    public float moveSpeed = 2f;
    public float jumpForce = 5f;
    public int coinReward = 10;
    public Transform[] patrolPoints;

    private int currentPoint = 0;
    private int currentHealth;
    private bool isDead = false;
    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead || patrolPoints.Length == 0) return;

        // Patrol between points
        Transform targetPoint = patrolPoints[currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            Debug.Log("Rat hit spike — jumping over!");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Jump up
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Rat Boss hit the player!");

            // Damage the player
            Death playerHealth = collision.gameObject.GetComponent<Death>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); // Customize the damage amount
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("Rat Boss defeated!");

        // Reward player
        RewardSystem.Instance.AddCoins(coinReward);

        Destroy(gameObject);
    }
}


