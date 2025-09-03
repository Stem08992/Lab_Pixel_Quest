using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPurchase : MonoBehaviour
{
   //public Text4 coinText;
   //public Button3 buySwordButton;
   //public Text5 swordStatusText;
    public int swordCost = 50;

    void Start()
    {
        UpdateUI();

        // Check if already bought
        if (PlayerPrefs.GetInt("SwordPurchased", 0) == 1)
        {
           // swordStatusText.text = "Already Purchased!";
          //  buySwordButton.interactable = false;
        }
    }

    public void BuySword()
    {
        if (RewardSystem.Instance.coins >= swordCost)
        {
            RewardSystem.Instance.coins -= swordCost;
            RewardSystem.Instance.SaveCoins();

            PlayerPrefs.SetInt("SwordPurchased", 1); // Save unlock
            PlayerPrefs.Save();

           // swordStatusText.text = "Purchased!";
           //buySwordButton.interactable = false;

            Debug.Log("Sword purchased!");
        }
        else
        {
            //swordStatusText.text = "Not enough coins!";
            Debug.Log("Not enough coins!");
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        //coinText.text = "Coins: " + RewardSystem.Instance.coins;
    }
}