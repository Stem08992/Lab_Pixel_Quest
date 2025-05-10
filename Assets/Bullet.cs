using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        Destroy(gameObject, 3f); // Destroy the bullet after 3 seconds
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); // Move bullet forward
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyBehavior>().TakeDamage(); // Damage enemy
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
