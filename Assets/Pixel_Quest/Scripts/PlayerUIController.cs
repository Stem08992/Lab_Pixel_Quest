using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    public Image heart_Image;
    public TextMeshProUGUI coinText;
    public Image stressBar;

    // Start is called before the first frame update
    public void Start()
    {
       // heart_Image = GameObject.Find("HeartImage").GetComponent<Image>();
       coinText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
        stressBar = GameObject.Find("StressBar").GetComponent<Image>();
    }
    public void UpdateStress(float currentHealth, float maxHealth)
    {
        stressBar.fillAmount = currentHealth / maxHealth;
    }
    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        heart_Image.fillAmount = currentHealth / maxHealth;
    }

    public void UpdateCoinText(string newText)
    {
        coinText.text = newText;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
