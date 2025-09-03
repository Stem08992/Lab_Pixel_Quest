using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        Debug.Log(xInput);
        rb.velocity = new Vector2(xInput, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
    }
}
