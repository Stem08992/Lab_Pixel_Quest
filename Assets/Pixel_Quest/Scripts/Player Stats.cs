using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    //public string nextLevel = "GeoLevel_2";
    public Transform respawnPoint;
    private int coinCounter = 0;
    public int _health = 3;
    public int maxHealth = 3;
    private PlayerUIController _playerUIController;

    private void Start()
    {
        _playerUIController = GetComponent<PlayerUIController>();
        _playerUIController.UpdateHealth(_health, maxHealth);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Respawn":
                {
                    respawnPoint.position = other.transform.Find("Point").position;
                    break;
                }
            case "Death":
                {
                    _health--;
                    _playerUIController.UpdateHealth(_health, maxHealth);
                    if (_health <= 0)
                    {
                        string thislevel= SceneManager.GetActiveScene().name;
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
                    Destroy(other.gameObject);
                    break;
                }
            case "Finish":
                {
                  string nextLevel = other.GetComponent<LevelGoals>().nextLevel;
                    SceneManager.LoadScene(nextLevel);
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