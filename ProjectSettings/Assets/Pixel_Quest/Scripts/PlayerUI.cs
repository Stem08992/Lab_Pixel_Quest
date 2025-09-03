using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerUI : MonoBehaviour
{
    public Image playerhealth;

    // Start is called before the first frame update
    private void Start()
    {
        playerhealth = GameObject.Find("HeartImage").GetComponent<Image>();
        
    }

    // Update is called once per frame
    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        playerhealth.fillAmount = currentHealth / maxHealth;
    }    
        
    
}
