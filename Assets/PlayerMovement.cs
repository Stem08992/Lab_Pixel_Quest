using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    void Update()
    {
        // Collect user input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Update Animator parameter
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // Move player using physics
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
