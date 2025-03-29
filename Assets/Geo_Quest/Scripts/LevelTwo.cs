using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwo : MonoBehaviour
{
    public float amount = 2f;
    public float jumpAmount = 5f;

    private bool coin = false;

    public string Level2 = "Scene_2";

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * amount, rb.velocity.y);
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
                    Debug.Log("Touched");
                    coin = false;
                    string level2 = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(level2);
                    break;
                }
            case "Coin":
                {
                    coin = true;

                    break;
                }


            case "Finish":
                {
                    if (coin == true)
                    {
                        SceneManager.LoadScene(Level2);
                    }
                    break;
                }
        }
    }
}
