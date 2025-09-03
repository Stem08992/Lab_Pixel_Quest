using UnityEngine;
using UnityEngine.UI; // For UI Text
using TMPro;
public class CoinCollector : MonoBehaviour
{
    public int coinCount = 0; // Total coins collected
    public TextMeshProUGUI coinText; // Drag your UI Text component here

    void Start()
    {
        UpdateCoinUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount+=20;
            Destroy(other.gameObject);
            UpdateCoinUI();
        }
    }

    void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "Cash: " + coinCount;
        }
    }

    
}