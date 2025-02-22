using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public float amount = 2f;
    public float jumpAmount = 5f;

    private bool coin = false;
    private bool next = false;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (xInput * amount, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
                {
                    coin = false;
                    string level = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(level);
                    break;
                }
            case "coin":
                {
                    coin = true;
                    break;
                }
            case "Finish":
                {
                    if (coin == true)
                    {
                        string level2 = SceneManager.GetActiveScene().name;
                        SceneManager.LoadScene(level2);
                    }
                break;
                }
        }
    }
}
