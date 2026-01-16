using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoController5 : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    public int speed = 5;
    public string nextLevel = "Scene_2";
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sprite.color= Color.white;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sprite.color = Color.yellow;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sprite.color = Color.magenta;
        }
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

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
        Debug.Log("Hit");
    }
}
