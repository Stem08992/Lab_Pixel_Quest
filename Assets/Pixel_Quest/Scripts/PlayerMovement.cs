using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMOvement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float speed = 5f;
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
       

    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xMovement * speed, rb.velocity.y);

        if (xMovement > 0) { _spriteRenderer.flipX = true; }
        else if (xMovement < 0) { _spriteRenderer.flipX = false;}
    }
}
