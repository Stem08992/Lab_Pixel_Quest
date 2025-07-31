using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    public int speed = 4;
    public string nextLevel = "Level2";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sp.color = Color.red;
        }


        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sp.color = Color.blue;
        }


        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sp.color = Color.magenta;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
                {
                    string thislevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thislevel);
                    break;
                }
            case "Finish":
                {
                    SceneManager.LoadScene(nextLevel);
                    break;
                }


            }

        }


        /*
         {

       Debug.Log(xInput);


        if (Input.GetKeyDown(KeyCode.W))
            transform.position += new Vector3(0, 1, 0);
        if (Input.GetKeyDown(KeyCode.S))
            transform.position += new Vector3(0, -1, 0);
        if (Input.GetKeyDown(KeyCode.D))
            transform.position += new Vector3(1, 0, 0);
        if (Input.GetKeyDown(KeyCode.A))
            transform.position += new Vector3(-1, 0, 0);
            } 
           */
    }



