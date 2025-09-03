using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int _coinCounter = 0;
    private int coinsInLevel = 0;
    public int _health = 3;
    public Transform RespawnPoint;
    public int _MaxHealth = 3;
    public ShopMenu shopMenu;
    private PlayerUIController _playerUIController;
    private GameManager _gameManager;

    private void Start()
    {
        coinsInLevel = GameObject.Find("Coins").transform.childCount;
        _gameManager = GameManager.Instance;
        if(_gameManager.coinCount > 0)
        {
            shopMenu.MenuOnOff(true);
        } else         {
            shopMenu.MenuOnOff(false);
        }

        _playerUIController = GetComponent<PlayerUIController>();
        _playerUIController.StartUI();
        _playerUIController.UpdateHealth(_health, _MaxHealth);
        _playerUIController.UpdateCoin(_coinCounter + "/" + coinsInLevel);
        _playerUIController.UpdateCoinGlobal("Coins: " + _gameManager.coinCount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Finish":
                {
                    string nextLevel = collision.GetComponent<LevelGoal>().nextLevel;
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
            case "Death":
                {
                    _health--;
                    _playerUIController.UpdateHealth(_health, _MaxHealth);
                    if (_health <= 0)
                    {
                        if (_gameManager.coinCount > 0)
                        {
                            shopMenu.MenuOnOff(true);
                        }
                        else
                        {
                            shopMenu.MenuOnOff(false);
                        }

                        string thisLevel = "Level 1";
                        SceneManager.LoadScene(thisLevel);
                    }
                    else
                    {
                        transform.position = RespawnPoint.position;
                    }
                    break;
                }
            case "Coin":
                {
                    // Grand total coins
                    _gameManager.AddCoins(1);
                    // Update global coin count text
                    _playerUIController.UpdateCoinGlobal("Coins: " + _gameManager.coinCount);

                    // Coins in this level
                    _coinCounter++;
                    _playerUIController.UpdateCoin(_coinCounter + "/" + coinsInLevel);
                    
                    Destroy(collision.gameObject);
                    break;
                }
            case "Health":
                {
                    if (_health < 3)
                    {
                        _health++;
                        _playerUIController.UpdateHealth(_health, _MaxHealth);
                        Destroy(collision.gameObject);
                    }
                    break;
                }
            case "Respawn":
                {
                    RespawnPoint.position = collision.transform.Find("Point").position;
                    break;
                }
               
        }
    }
}