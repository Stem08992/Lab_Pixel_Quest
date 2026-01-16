using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    public Image Heart;
    public TextMeshProUGUI cointext;
    // Start is called before the first frame update
    private void Start()
    {
        Heart = GameObject.Find("Heartimage").GetComponent<Image>();
        cointext=GameObject.Find("cointext").GetComponent<TextMeshProUGUI>();
    }
    
    // Update is called once per frame
    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        Heart.fillAmount = currentHealth / maxHealth;
    }
    public void UpdateCoin(string newtext)
    {
        cointext.text = newtext;
    }
        
    
}
