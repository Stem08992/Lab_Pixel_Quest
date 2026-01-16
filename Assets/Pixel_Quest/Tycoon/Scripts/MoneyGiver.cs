using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyGiver : MonoBehaviour
{
    public int money;
    public int amount;
    public float timer = 5f;
    private float currenttime = 0f;
    public TextMeshPro moneyText;
    private void Buttonmoneyincrease()
    {
        currenttime -=Time.deltaTime;
        if (currenttime < 0)
        {
            currenttime = timer;
            money += amount;
            UpdateMoneyText();
        }

    }

    public int Givemoney()
    {
        int givemoney = money;
        money = 0;
        return givemoney;
    }

    private void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            moneyText.text = "$" + money.ToString();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Buttonmoneyincrease();
    }
}
