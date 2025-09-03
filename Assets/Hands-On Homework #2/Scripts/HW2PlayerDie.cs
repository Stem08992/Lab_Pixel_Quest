using UnityEngine;

public class HW2PlayerDie : MonoBehaviour
{
    private string Enemy = "Enemy";
    public GameObject endPannel;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Enemy)
        {
            endPannel.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
