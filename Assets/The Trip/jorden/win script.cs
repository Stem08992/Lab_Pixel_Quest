using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Optional: check tag to make sure it's the correct object
        if (other.CompareTag("Win"))
        {
            SceneManager.LoadScene("train");
        }
    }
}