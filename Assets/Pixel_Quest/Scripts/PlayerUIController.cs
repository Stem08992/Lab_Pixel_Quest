using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{

    public Image heartImage;

    public void Start()
    {
        heartImage = GameObject.Find("heartImage").GetComponent<Image>();
    }

    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        heartImage.fillAmount = currentHealth / maxHealth;
    }   
}
