using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GeoController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer rbSprite;
    string var1 = "Hello";
    int x_Value = 0;
    int y_Value = 0;
    public int speed = 3;
    public string nextLevel = "Scene_2";
    Color color = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
        rbSprite.color = color;
        Debug.Log("Hello World!");
        string var2 = "World!";
        Debug.Log(var1 +" " + var2);
        if (SceneManager.GetActiveScene().name.Equals("Scene_2"))
        {
            nextLevel = "Scene_3";
        }
        
    }// end start

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Pressing 1");
            color = Color.yellow;
            rbSprite.color = Color.yellow;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            color = Color.cyan;
            rbSprite.color = Color.cyan;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            color = Color.green;
            rbSprite.color = Color.green;
        }

        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
        //Debug.Log(xInput);

    }// end update

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);
        switch(collision.tag)
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
}// end class
