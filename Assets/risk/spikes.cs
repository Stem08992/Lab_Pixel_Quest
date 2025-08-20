using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spike : MonoBehaviour
{
    // We need to detect when the player hits the spike
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            // Call the function to kill the player (you can reset or show a death screen)
            KillPlayer(other.gameObject);
        }
    }

    void KillPlayer(GameObject player)
    {
        // If the player hits the spike, we will destroy the player or reset the scene
        // Destroy the player for a death effect (optional: add sound, particle effect, etc.)
        Destroy(player);

        // Optionally, you can reload the level (restart the scene) after a short delay
        // This gives the player time to see the death animation
        Invoke("RestartLevel", 1f);
    }

    void RestartLevel()
    {
        // Restart the scene when the player dies
        // You can use SceneManager to reload the scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
public class spikes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
