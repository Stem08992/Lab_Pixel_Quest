using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneWalk : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2;
    public float spd = 2;
    private int direction = 1;
    public float capsuleHeight = 0.25f;
    public float capsuleRadius = 0.08f;

    public Transform feetCollider;
    public LayerMask groundMask;
    public bool groundCheck;
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2.velocity = new Vector2(spd * direction, rb2.velocity.y);

        groundCheck = Physics2D.OverlapCapsule(feetCollider.position,
            new Vector2(capsuleHeight, capsuleRadius), CapsuleDirection2D.Horizontal,
            0, groundMask);

        if (!groundCheck)
        {
            direction *= -1;
            transform.localScale = new Vector3(direction * 4, 4, 4);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction *= -1;
        transform.localScale = new Vector3(direction * 4, 4, 4);
    }
}