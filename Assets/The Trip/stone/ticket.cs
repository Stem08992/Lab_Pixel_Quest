using UnityEngine;
using UnityEngine.UI; // For UI Text
using TMPro;

public class ticket : MonoBehaviour
{
    public int ticketCount = 0; // Total coins collected
    public TextMeshProUGUI ticketText; // Drag your UI Text component here

    void Start()
    {
        UpdateticketUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ticket"))
        {
            ticketCount ++;
            Destroy(other.gameObject);
            UpdateticketUI();
        }
    }

    void UpdateticketUI()
    {
        if (ticketText != null)
        {
            ticketText.text = "ticket: " + ticketCount;
        }
    }
}