using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 2f;
    public int health = 5;
    private Transform player;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootInterval = 2f; // Time between shots
    private float shootTimer;
    public int EnemiesKilled = 0;
    [SerializeField] public Mymove playerscript;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        playerscript = player.GetComponent<Mymove>();
        shootTimer = shootInterval; // Start with the ability to shoot
    }

    void Update()
    {
        // If the player exists, move towards the player
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }

        // Shooting logic
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootInterval; // Reset timer for next shot
        }

        
    }

    void Shoot()
    {
        if (bulletPrefab && firePoint)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();

            // Get direction from enemy to player
            Vector2 direction = (player.position - transform.position).normalized;

            // Shoot the bullet towards the player
            rbBullet.velocity = direction * 5f; // Adjust bullet speed if needed
        }
    }

    public void TakeDamage()
    {
        health--;
        //enemy dies because no more health
        if (health <= 0)
        {
            playerscript.EnemyCounter += 1;
            Debug.Log("enemies killed: " + playerscript.EnemyCounter);
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage();
            Destroy(collision.gameObject); // Destroy bullet
        }
    }
}
