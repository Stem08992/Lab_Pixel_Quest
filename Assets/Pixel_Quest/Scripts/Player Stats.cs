using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public Transform respawnPoint;
    private int coinCounter = 0;
    public int _health = 3;
    public int maxHealth = 3;
    private PlayerUIController _playerUIController;
    public int CoinInLevel = 0;

    private void Start()
    {
        _playerUIController = GetComponent<PlayerUIController>();
        _playerUIController.StartUI();
        _playerUIController.UpdateHealth(_health, maxHealth);
        CoinInLevel = GameObject.Find("Coins").transform.childCount;
        _playerUIController.UpdateText(coinCounter + "/" + CoinInLevel);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Respawn":
                {
                    Transform point = other.transform.Find("Point");
                    if (point != null)
                    {
                        respawnPoint.position = point.position;
                    }
                    else
                    {
                        Debug.LogWarning("Respawn trigger is missing a child named 'Point'.");
                    }
                    break;
                }
            case "Death":
                {
                    _health--;
                    _playerUIController.UpdateHealth(_health, maxHealth);
                    if (_health <= 0)
                    {
                        string thislevel = SceneManager.GetActiveScene().name;
                        SceneManager.LoadScene(thislevel);
                    }
                    else
                    {
                        transform.position = respawnPoint.position;
                    }
                    break;
                }
            case "Coin":
                {
                    coinCounter++;
                    _playerUIController.UpdateText(coinCounter + "/" + CoinInLevel);
                    Destroy(other.gameObject);
                    break;
                }
            case "Finish":
                {
                    LevelGoals goals = other.GetComponent<LevelGoals>();
                    if (goals != null)
                    {
                        string nextLevel = goals.nextLevel;
                        SceneManager.LoadScene(nextLevel);
                    }
                    else
                    {
                        Debug.LogWarning("Finish trigger is missing the LevelGoals component.");
                    }
                    break;
                }
            case "Health":
                {
                    if (_health < 3)
                    {
                        _health++;
                        _playerUIController.UpdateHealth(_health, maxHealth);
                        Destroy(other.gameObject);
                    }
                    break;
                }
        }
    }
}
