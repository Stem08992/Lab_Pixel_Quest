using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer srU;
    private SpriteRenderer srD;
    //sprite render top and bottom
    private Rigidbody2D rb;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        srU = transform.GetChild(0).GetComponent<SpriteRenderer>();
        srD = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

        if(xInput > 0){
            srU.flipX = true;
            srD.flipX = true;
        } else if(xInput < 0){
            srU.flipX = false;
            srD.flipX = false;
        }
    }
}
