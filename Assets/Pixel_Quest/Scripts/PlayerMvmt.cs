using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvmt : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public int speed = 4;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _spriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        _rigidbody2D.velocity = new Vector2(horizontal * speed, _rigidbody2D.velocity.y);

        if (horizontal == 1)
        {
            _spriteRenderer.flipX = true;
        }
        if (horizontal == -1)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
