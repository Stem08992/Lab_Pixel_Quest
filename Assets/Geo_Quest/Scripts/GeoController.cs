using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class GeoController : MonoBehaviour
{
    string String = "burger";
    int burger = 3;
    public string nextlevel = "level_2";
    Rigidbody2D rb;
    float speed = 5;
    // Start is called before the first frame update
    void Start()
    {rb =GetComponent<Rigidbody2D>();
      

     Debug.Log("burger");
     string String2= "burger";
        Debug.Log(String2+ String2);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(burger);
        burger++;
        /*
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0, 1, 0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += new Vector3(0, -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
     
       transform.position += new Vector3(1, 0, 0);
        }
        */
        /*
        if(Input.GetKeyDown(KeyCode.A));
        {
            rb.velocity = new Vector2(-1, rb.velocity.y);

        }
        if (Input.GetKeyDown)(KeyCode.S))
        {

            rb.velocity = new Vector2 (1, rb.velocity.y)
        }
        */

        float xinput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xinput * speed, rb.velocity.y);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Run Killer");
        switch (collision.tag)
        {
            case "Death":
                {
                    string level1 = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(level1);
                    break;
                }
            case "Finish":
                {
                    SceneManager. LoadScene(nextlevel); break;
                }
        }
    }
    
}

