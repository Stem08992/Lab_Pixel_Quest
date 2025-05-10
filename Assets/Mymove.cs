using UnityEngine;
using UnityEngine.SceneManagement;

public class Mymove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded = true;

    // Bullet shooting variables
    public GameObject bulletPrefab;  // The bullet prefab to instantiate
    public Transform firePoint;      // The point from where bullets will be fired
    public float bulletSpeed = 10f;  // Speed at which the bullet moves

    public float verticalSpeed = 5f;  // Speed for moving up/down

    public int Targetkilled = 10; // how many enemies to defeat before moving on
    public int EnemyCounter = 0;

    public string nextLevel = "first level 2";
    //[SerializeField] public EnemyBehavior EnemyBehaviorScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //EnemyCounter += EnemyBehaviorScript.EnemiesKilled;
        // When the player killed enough enemies it moves to next level //
        if (EnemyCounter >= Targetkilled)
        {
            Debug.Log("target reached, go next level");
            SceneManager.LoadScene(nextLevel);
        }

        // Player Movement (left and right)
        float moveDirection = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection = -1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection = 1f;
        }

        // Player Up/Down Movement
        float verticalDirection = 0f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) // Move up
        {
            verticalDirection = 1f;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // Move down
        {
            verticalDirection = -1f;
        }

        // Apply movement to Rigidbody
        rb.velocity = new Vector2(moveDirection * moveSpeed, verticalDirection * verticalSpeed);

        // Jump functionality (optional)
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            Jump();
        }

        // Shoot bullet when mouse button is pressed or 'F' key is pressed
        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if(EnemyCounter > 10)
        {
            SceneManager.LoadScene(nextLevel);  
        }
    }

    // Jump method
    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.contacts[0].normal.y > 0.5f) // Check if landing on ground
        {
            isGrounded = true;
        }
    }

    // Shoot method to instantiate bullet and make it move
    void Shoot()
    {
        if (bulletPrefab && firePoint)
        {
            // Instantiate the bullet at the firepoint
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();

            // Get mouse position in world space
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Get direction from firepoint to mouse position
            Vector2 shootDirection = (mousePosition - (Vector2)firePoint.position).normalized;

            // Set bullet velocity in that direction
            rbBullet.velocity = shootDirection * bulletSpeed;
        }
    }
}
