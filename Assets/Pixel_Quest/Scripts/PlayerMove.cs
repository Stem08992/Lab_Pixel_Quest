using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer sr1;
    public int speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        sr1 = GetComponentInChildren<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {


        float xInput = Input.GetAxis("Horizontal");
        if (xInput > 0) { sr1.flipX = true; }
        else if (xInput < 0) { sr1.flipX= false; }
        _rigidbody2D.velocity = new Vector2(xInput * speed, _rigidbody2D.velocity.y);
    }
}
