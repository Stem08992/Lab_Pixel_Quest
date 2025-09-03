using UnityEngine;
using UnityEngine.SceneManagement; // For scene reload if needed

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 2;
    public int currentHealth;
    public Transform spawnPoint; // Optional: assign spawn point for respawning

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Death"))
        {
            TakeDamage(1); // Inflict massive damage to ensure death
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Optional: play death animation, effects, sounds
        // For example, disable the player or hide it
        gameObject.SetActive(false);

        // Respawn or reload scene
        // Example: Respawn at spawn point
        if (spawnPoint != null)
        {
            Respawn();
        }
        else
        {
            // Or reload scene
            ReloadScene();
        }
    }

    void Respawn()
    {
        // Reset health
        currentHealth = maxHealth;
        // Move to spawn point
        transform.position = spawnPoint.position;
        // Reactivate player
        gameObject.SetActive(true);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}