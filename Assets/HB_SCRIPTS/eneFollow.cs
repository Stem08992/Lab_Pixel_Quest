using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eneFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float moveSpeed = 1.5f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector2 direction = ((Vector2)player.position - rb.position).normalized;
            Vector2 newPosition = rb.position + direction * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        }
    }
}
