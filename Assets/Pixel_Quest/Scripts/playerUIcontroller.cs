using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class playerUIcontroller : MonoBehaviour
{
    public Image heartImage;
    private TextMeshProUGUI _text;
    // Start is called before the first frame update

    public void StartUI()
    {
        heartImage = GameObject.Find("HeartImage").GetComponent<Image>();
        _text = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
    }
    public void UpdateText(string newText)
    {
        _text.text = newText;
    }
    public void UpdateHealth(float currentHealth,float maxHealth)
    {
        heartImage.fillAmount = currentHealth / maxHealth;
    }

    // Update is called once per frame
   
}
