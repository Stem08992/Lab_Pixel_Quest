using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    public TextMeshProUGUI TMPU;
    public Image heartImage;
    public TextMeshProUGUI dashCooldownText;


    public void StartUI()
    {
        if (heartImage == null)
            heartImage = GameObject.Find("HeartImage")?.GetComponent<Image>();

        if (TMPU == null)
            TMPU = GameObject.Find("CoinText")?.GetComponent<TextMeshProUGUI>();
        if (dashCooldownText == null)
    dashCooldownText = GameObject.Find("DashCooldownText")?.GetComponent<TextMeshProUGUI>();

    }

    public void UpdateText(string newText)
    {
        if (TMPU != null)
            TMPU.text = newText;
    }

    public void UpdateHealth(float Health, float maxHealth)
    {
        if (heartImage != null)
            heartImage.fillAmount = Health / maxHealth;
    }
    public void UpdateDashCooldown(float cooldown)
{
    if (dashCooldownText != null)
    {
        if (cooldown <= 0)
            dashCooldownText.text = "Dash Ready!";
        else
            dashCooldownText.text = "Dash in: " + Mathf.CeilToInt(cooldown) + "s";
    }
}

}

