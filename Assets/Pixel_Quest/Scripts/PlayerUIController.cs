using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    // Start is called before the first frame update
    public Image heartImage;
    public TextMeshProUGUI UITextMeshProUGUI;
    public void StartUI()
    {
        UITextMeshProUGUI = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
        heartImage = GameObject.Find("HeartImage").GetComponent<Image>();
    }
    public void UpdateText(string newText)
    {
        UITextMeshProUGUI.text = newText;
    }

    // Update is called once per frame
    void Update()
    {
        //heartImage.fillAmount = currentHealth / maxHealth;
    }
    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        Debug.Log("Check " + currentHealth);
        heartImage.fillAmount = currentHealth / maxHealth;
    }
}
