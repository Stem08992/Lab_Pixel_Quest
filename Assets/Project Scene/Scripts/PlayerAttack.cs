using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    private Vector2 lastMoveDirection;

    void Update()
    {
        // 1. Capture Movement Input to track direction
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveX != 0 || moveY != 0)
        {
            lastMoveDirection = new Vector2(moveX, moveY).normalized;
        }

        // 2. Check for Space Bar press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformSlash();
        }
    }

    void PerformSlash()
    {
        // Decide which animation to play based on lastMoveDirection
        if (Mathf.Abs(lastMoveDirection.x) > Mathf.Abs(lastMoveDirection.y))
        {
            if (lastMoveDirection.x > 0) animator.Play("Slash_Right");
            else animator.Play("Slash_Left");
        }
        else
        {
            if (lastMoveDirection.y > 0) animator.Play("Slash_Up");
            else animator.Play("Slash_Down");
        }
    }
}