using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    public Image heartImage;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI coinTextGlobal;
    
    // Start is called before the first frame update
    public void StartUI()
    {
       heartImage = GameObject.Find("heartImage").GetComponent<Image>();
       coinText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        heartImage.fillAmount = currentHealth / maxHealth;
    }
    public void UpdateCoin(string newText)
    {
        coinText.text = newText;
    }

    public void UpdateCoinGlobal(string newText)
    {
        coinTextGlobal.text = newText;
    }
}

