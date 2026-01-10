using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoController : MonoBehaviour
{
    public string variable1 = "Hello";
    string variable2 = "World";
    private int var1 = 51;
    private Rigidbody2D rb;
    public int speed = 5;
    public string nextLevel = "Game 1";
    // Start is called before the first frame update
    void Start()

    {
       // string variable2 = "World";
        Debug.Log(variable2);

        Debug.Log("Hello World");
        Debug.Log(variable1 + variable2);
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
        
    {
     
       // rb.velocity = new Vector2(-1,rb.velocity.y);
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (xInput* speed, rb.velocity.y);
        Debug.Log(xInput);

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
      */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");

        switch (collision.tag)
        {
            case "Death":
                {
                    Debug.Log("D");
                    
                      string thisLevel = SceneManager .GetActiveScene().name;   
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
    }

        