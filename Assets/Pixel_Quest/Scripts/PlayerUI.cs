using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;
public class PlayerUI : MonoBehaviour
{
    public Image playerhealth; 
    public TextMeshProUGUI CoinText;

    // Start is called before the first frame update
    public void StartUI()
    {
        playerhealth = GameObject.Find("playerhealth").GetComponent<Image>();
        CoinText = GameObject.Find("CoinText").GetComponentInParent<TextMeshProUGUI>();  
    }

    // Update is called once per frame
    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        playerhealth.fillAmount = currentHealth / maxHealth;
    }




}

