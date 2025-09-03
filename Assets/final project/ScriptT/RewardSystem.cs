using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HW3Structs;

public class RewardSystem : MonoBehaviour
{
    public static RewardSystem Instance;

    public int coins = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadCoins();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        SaveCoins();
    }

    public void SaveCoins()
    {
        PlayerPrefs.SetInt("Coins", coins);
    }

    public void LoadCoins()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
    }
}

