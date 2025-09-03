using UnityEngine;
using UnityEngine.UI; // Include for UI components

public class PlayerCoinCollector : MonoBehaviour
{
    public int coinCount = 0;
    public Text coinText; // Drag your UI Text here in the inspector

    void Start()
    {
        UpdateCoinUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            Destroy(other.gameObject);
            UpdateCoinUI();
        }
    }

    void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinCount;
        }
    }
}