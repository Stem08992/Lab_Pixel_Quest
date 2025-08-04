using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HHQPlayerMovement : MonoBehaviour
{
    public int homelessHelped = 0; // Tracks how many homeless people you've helped
    public Text homelessHelpedText; // UI Text to display the count

    void Start()
    {
        UpdateUI();
    }

    // Call this method when a homeless person is brought to the shelter
    public void AddHomelessHelped(int amount)
    {
        homelessHelped += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (homelessHelpedText != null)
        {
            homelessHelpedText.text = "People Helped: " + homelessHelped.ToString();
        }
    }
}