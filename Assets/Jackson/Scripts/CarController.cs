using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoints : MonoBehaviour
{
    public float waitTime = 1f;
    private float currentTime = 1f;
    public float speed = 5f;
    public float rotationSpeed = 360f;
    public Transform[] patrolPoints;

    private int patrolIndex = 0;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        transform.position = patrolPoints[patrolIndex].position;
        currentTime = waitTime;

        // Cache the SpriteRenderer
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (!spriteRenderer)
        {
            Debug.LogError("SpriteRenderer not found on " + gameObject.name);
        }
    }

    void Update()
    {
        Transform target = patrolPoints[patrolIndex];

        // Direction and rotation
        Vector2 direction = (target.position - transform.position);
        if (direction.sqrMagnitude > 0.001f)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        // Move toward the target
        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        // Arrival check
        if ((Vector2)transform.position == (Vector2)target.position)
        {
            if (currentTime <= 0f)
            {
                int prevIndex = patrolIndex;

                patrolIndex++;
                if (patrolIndex >= patrolPoints.Length)
                {
                    patrolIndex = 0;
                }

                // Set visibility based on transition from last → 0
                if (prevIndex == patrolPoints.Length - 1 && patrolIndex == 0)
                {
                    spriteRenderer.enabled = false; // hide
                }
                else
                {
                    spriteRenderer.enabled = true;  // show
                }

                currentTime = waitTime;
            }
            else
            {
                currentTime -= Time.deltaTime;
            }
        }
    }
}
