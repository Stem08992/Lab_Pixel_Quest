using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public GameObject slashPrefab; // Drag your Slash Prefab here
    public Transform attackPoint;  // A child object of Player to set spawn position
    
    private Vector2 lastMoveDirection;

    void Update()
    {
        // 1. Track Movement Direction (Assumes standard WASD/Arrow input)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveX != 0 || moveY != 0)
        {
            lastMoveDirection = new Vector2(moveX, moveY).normalized;
        }

        // 2. Listen for Space Bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformAttack();
        }
    }

    void PerformAttack()
    {
        // Determine rotation based on last movement
        float angle = Mathf.Atan2(lastMoveDirection.y, lastMoveDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle - 90f);

        // Spawn the slash
        Instantiate(slashPrefab, attackPoint.position, rotation, transform);
    }
}