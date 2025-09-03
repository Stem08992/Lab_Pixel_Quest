using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public int coinCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Avoid duplicates when reloading
        }
    }

    public void AddCoins(int amount)
    {
        Debug.Log("Adding Coins: " + amount);
        coinCount += amount;
        Debug.Log("Total Coins: " + coinCount);
    }

    public void SubtractCoins(int amount)
    {
        Debug.Log("Subtracting Coins: " + amount);
        coinCount -= amount;
        Debug.Log("Total Coins: " + coinCount);
    }
}
