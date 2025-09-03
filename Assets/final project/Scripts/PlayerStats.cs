using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int coinCount = 0;
    public int Health = 1;
    public int maxHealth = 1;
    public int CoinsInLevel = 0;

    

    private PlayerUIController uiController;

    void Start()
    {
        uiController = GetComponent<PlayerUIController>();
        uiController.StartUI();

        uiController.UpdateHealth(Health, maxHealth);

        CoinsInLevel = GameObject.Find("Coins").transform.childCount;
        uiController.UpdateText(coinCount + " / " + CoinsInLevel);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        switch (other.tag)
        {
            case "Death":

                uiController.UpdateHealth(Health, maxHealth);
                string thisLevel = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(thisLevel);

                break;

            case "Coin":
                coinCount++;
                uiController.UpdateText(coinCount + " / " + CoinsInLevel);
                Destroy(other.gameObject);
                break;

            case "Health":
                if (Health < maxHealth)
                {
                    Health++;
                    uiController.UpdateHealth(Health, maxHealth);
                    Destroy(other.gameObject);
                }
                break;

            case "Rat":
                Health--;
                if (Health <= 0)
                {
                    thisLevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thisLevel);
                }
                break;

            case "Finish":
            // if (coinCount==20)
                {
                    string nextLevel = other.GetComponent<LevelGoal>().nextLevel;
                    SceneManager.LoadScene(nextLevel);
                }
                    break;
                
               

        }
    }
}
