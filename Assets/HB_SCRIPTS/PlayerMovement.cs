using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public int xSpeed = 4;
    private SpriteRenderer rbSprite;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = transform.Find("Sprite").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    rb.velocity += new Vector2(-1, rb.velocity.y);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    rb.velocity += new Vector2(1, rb.velocity.y);
        //}

        float xInput = Input.GetAxis("Horizontal");
        //Debug.Log(xInput);

        rb.velocity = new Vector2(xInput * xSpeed, rb.velocity.y);
    }
}
