using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed = 8;
    private int direction = 1;

    private float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;


    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundcheck;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.velocity = new Vector2(speed * direction, _rb.velocity.y);


        _groundcheck = Physics2D.OverlapCapsule(feetCollider.position,
        new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal, 0, groundMask);

        if (!_groundcheck)
        {
            direction *= -1;
            transform.localScale = new Vector3(direction, 1, 1);
    }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction *= -1;
        transform.localScale = new Vector3(direction, 1, 1);
    } 

}
