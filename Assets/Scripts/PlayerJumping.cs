using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    // Rigidbody
    private Rigidbody2D rigidbody2D; // Controls the speed 
    public float JumpForce = 4; // Controls how high the player jumps 

    // Checks
    public Transform ground;     // Where the collision will be checked for 
    public LayerMask groundMask; // The layer we're looking for 
    private bool waterCheck;     // Is the player touching water 
    private int jumpCount = 0;   // Tracks how many jumps have been performed
    private int maxJumps = 2;    // Max number of jumps allowed (double jump)

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the player is touching any object whose LayerMask is called Ground
        bool groundCheck = Physics2D.OverlapCapsule(ground.position, new Vector2(1, 0.08f), CapsuleDirection2D.Horizontal, 0, groundMask);

        // Reset jump count when the player is on the ground
        if (groundCheck)
        {
            jumpCount = 0;
        }

        // Check if the player can jump
        if (Input.GetKeyDown(KeyCode.Space) && (jumpCount < maxJumps || waterCheck))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
            jumpCount++; // Increment jump count each time a jump occurs
        }
    }

    // Checks if the player has touched water, if so let them jump
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            waterCheck = true;
        }
    }

    // Checks if the player has left water, if so they can't jump
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            waterCheck = false;
        }
    }
}