
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GeoController : MonoBehaviour

{

    private Rigidbody2D rb;
    private SpriteRenderer sc;
    public int speed = 5;
    public string nextLevel = "Scene_2";

    // Start is called before the first frame update
    //private void OnTriggerEnter2D(Collider2D collision);
    //{Debug.log("Hit");}
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sc = GetComponent<SpriteRenderer>();

    }

    //GetComponent<SpriteRenderer>().material.color = new Color(0, 204, 102);


    // Update is called once per frame
    void Update()
    {

         
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GetComponent<SpriteRenderer>().material.color = new Color(200, 20, 50);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetComponent<SpriteRenderer>().material.color = new Color(0, 204, 102);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GetComponent<SpriteRenderer>().material.color = new Color(0, 0, 0);
        }

        float xinput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xinput * speed, rb.velocity.y);
        // if (Input.GetKeyDown(KeyCode.W))
        //{
            //transform.position += new Vector3(0, 1, 0);
        //}

        if (Input.GetKeyDown(KeyCode.A))
        {
            //rb.velocity = new Vector2(-1, -rb.velocity.y);
        }

        //if (Input.GetKeyDown(KeyCode.S))
        ///{
           // transform.position += new Vector3(0, -1, 0);
        //}

        if (Input.GetKeyDown(KeyCode.D))
        {
            //rb.velocity = new Vector2(1, -rb.velocity.y);
        }

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
//            transform.position += new Vector3(0, 1, 0);
  //      }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //rb.velocity = new Vector2(-1, -rb.velocity.y);
        }

    //    if (Input.GetKeyDown(KeyCode.DownArrow))
      //  {
        //    transform.position += new Vector3(0, -1, 0);
        //}

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
         //   rb.velocity = new Vector2(1, -rb.velocity.y);
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
}

   