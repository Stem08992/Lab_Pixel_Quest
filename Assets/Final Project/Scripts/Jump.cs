using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Components
    private Rigidbody2D _rigidbody2D;

    public float jumpforce = 10;
    public float fallforce = 2;
    private Vector2 _gravityVector;

    public float capsuleheight = 0.25f;
    public float capsuleradius = 0.08f;

    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;

    void Start()
    {
        _gravityVector = new Vector2(0, Physics2D.gravity.y);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _groundCheck = Physics2D.OverlapCapsule(feetCollider.position,
            new Vector2(capsuleheight, capsuleradius), CapsuleDirection2D.Horizontal,
            0, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && (_groundCheck))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpforce);
        }

        if (_rigidbody2D.velocity.y < 0)
        {
            _rigidbody2D.velocity += _gravityVector * (fallforce * Time.deltaTime);
        }
    }
}