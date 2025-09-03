using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class character : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer ss;
    public float speed;
    public float jump;
    public bool isJumping;
    private float Move;
    public string nextlevel = "here";

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ss = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ss.color = Color.white;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ss.color = Color.yellow;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ss.color = Color.green;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
                {
                    string thislevel=SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thislevel);
                    break;
                }
            case "Finish":
                {
                    SceneManager.LoadScene(nextlevel);
                    break;
                }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }
}