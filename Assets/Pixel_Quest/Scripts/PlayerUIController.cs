using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public Image heartImage;
    private TextMeshProUGUI CoinText;

    public void StartUI()
    {
        heartImage = GameObject.Find("heartImage").GetComponent<Image>();
        CoinText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(string newText)
    {
        CoinText.text = newText;
    }

    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        heartImage.fillAmount = currentHealth / maxHealth;
    }
}
