using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
    public Image Health;
    public TextMeshProUGUI Text;
    // Start is called before the first frame update
    public void StartUI()
    {
        Health = GameObject.Find("playerLifeUI").GetComponent<Image>();
        Text = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
    }

    public void UpdateHealth(float health, float maxHealth)
    {
        Health.fillAmount = health / maxHealth;
    }

    public void UpdateText(string newText)
    {
        Text.text = newText;
    }
}
