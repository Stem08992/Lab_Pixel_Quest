using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManvir : MonoBehaviour
{
    private Rigidbody2D rb1;
    public int xSpeed = 4;
    private SpriteRenderer rbSprite1;
    // Start is called before the first frame update
    void Start()
    {
        rb1 = GetComponent<Rigidbody2D>();
        rbSprite1 = transform.Find("Sprite").GetComponent<SpriteRenderer>();
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

        rb1.velocity = new Vector2(xInput * xSpeed, rb1.velocity.y);
    }
}


