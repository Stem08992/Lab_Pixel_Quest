using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedWalking : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;           // Controls players movement 
    private SpriteRenderer _spriteRenderer;     // Controls player image 
    public float xSpeed = 4;                    // Speed at which the player moves 

    public int playerHealth = 100; 

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        // Get sprite rendered from child object 
        _spriteRenderer = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Gets player input, -1 for Left Arrow/A, 0 for no key press, 1 for Right Arrow/D 
        float xInput = Input.GetAxis("Horizontal");

        // Flips the players image based on the direction the player is clicking 
        if (xInput < 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (xInput > 0)
        {
            _spriteRenderer.flipX = true;
        }

        // Put the speed in the player with given key input 
        _rigidbody2D.velocity = new Vector2(xInput * xSpeed, _rigidbody2D.velocity.y);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "GreenBullet")
        {
            Destroy(collision.gameObject);
            playerHealth -= 5;
            if (playerHealth < 0)
            {
                SceneManager.LoadScene("MenuLevel");
            }
        }
    }

}
