using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRat : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public int damage = 10;

    private bool movingRight = true;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        // Move rat
        float direction = movingRight ? 1f : -1f;
        rb.velocity = new Vector3(direction * moveSpeed, rb.velocity.y, 0);

        // Ground check to flip
        RaycastHit hit;
        if (!Physics.Raycast(groundCheck.position, Vector3.down, out hit, 1f, groundLayer))
        {
            Flip();
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Flip direction visually
        transform.localScale = scale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //PlayerHealth health = other.GetComponent<PlayerHealth>();
           // if (health != null)
            {
               // health.TakeDamage(damage);
            }
        }
    }
}

