using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class FinalGameUI : MonoBehaviour
{
    public Image stressBar;
    // Start is called before the first frame update
    public void Start()
    {
        stressBar = GameObject.Find("StressBar").GetComponent<Image>();
    }

    // Update is called once per frame
    public void UpdateStress(float currentHealth, float maxHealth)
    {
        stressBar.fillAmount = maxHealth-currentHealth / maxHealth;
    }
}