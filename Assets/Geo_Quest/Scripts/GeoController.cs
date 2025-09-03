
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.SceneManagement;
using Color = UnityEngine.Color;


public class GeoController : MonoBehaviour
{
    int varTwo = 3;
    private Rigidbody2D rb;
    public int speed = 5;
    public string nextLevel = "Scene_1";
    private SpriteRenderer _spriteRenderer;

    // Bro you're cooked
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
              {
                    string thisLevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thisLevel);
                    break;
              }
            case "Finish":
                {
                    SceneManager.LoadScene(nextLevel);
                    break;
                }

        }
    }



       // Update is called once per frame
    void Update()

    {
        
            float xInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _spriteRenderer.color = Color.blue;
            }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _spriteRenderer.color = Color.cyan;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _spriteRenderer.color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            _spriteRenderer.color = Color.yellow;
        }














        //Controls!!
        /*
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0); 
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += new Vector3(0, -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);
        }

        //End of Controls!!
        */
    }
}
