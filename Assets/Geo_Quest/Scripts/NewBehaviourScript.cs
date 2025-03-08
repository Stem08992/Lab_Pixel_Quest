using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshPro TextMeshPro;
    
    public float amount = 2f;
    public float jumpAmount = 5f;

    private bool coin = false;

    public string Level2 = "Scene_2";

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        TextMeshPro.text = "Objective: Get Coin";
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
            case "Coin":
                {
                    coin = true;
                    TextMeshPro.text = "Objective: Go Next Level";
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
