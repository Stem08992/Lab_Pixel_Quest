using UnityEngine;

public class HW2PlayerDie : MonoBehaviour
{
    [SerializeField] private GameObject endPanel; // Better practice than public
    private const string EnemyTag = "Enemy";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(EnemyTag))
        {
            if (endPanel != null)
            {
                endPanel.SetActive(true);
            }

            gameObject.SetActive(false);
        }
    }
}
