
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public int speed = 3;
    public string nextLevel = "GeoQuest 2";
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

       

     if (Input.GetKeyDown (KeyCode.Alpha1))
            {
            sr.color = new Color(1f, 0f, 0f); // Red color
        }
     
    if (Input.GetKeyDown (KeyCode.Alpha2))
            {
            sr.color = new Color(0f, 1f, 0f); // Green color
        }
     if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sr.color = new Color(0f, 0f, 1f); // Blue color
        }


    }




        //if (Input.GetKeyDown(KeyCode.A))
        // {
        //    rb.velocity = new Vector2(-1, rb.velocity.y);
        //  }
        // if (Input.GetKeyDown(KeyCode.D))
        // {
        //      rb.velocity = new Vector2(1, rb.velocity.x);
        //  }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            switch (collision.tag)
        {
            case "Death":
                {
                    string thisLevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thisLevel);
                    Debug.Log("Player has died");
                    break;
                }
            case "Finish":
                {
                
                    SceneManager.LoadScene(nextLevel);
                    Debug.Log("Player has finished the level");
                    break;
                }
        }
        
            }
        private void OnTriggerStay2D(Collider2D collision)
        {
        
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
        
        }
}

