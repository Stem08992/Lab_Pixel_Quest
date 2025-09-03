using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    //public string nextLevel = "GeoLevel_2"
    public int _coinCounter = 0;
    public int _health = 3;
    public Transform RespawnPoint;
    public int _maxHealth = 3;
    private PlayerUIController _playerUIController;
    private int coinsInLevel = 0;

    private void Start()
    {
        _playerUIController = GetComponent<PlayerUIController>();
        _playerUIController.UpdateHealth(_health, _maxHealth);

        coinsInLevel = GameObject.Find("Coins").transform.childCount;
        _playerUIController.UpdateCoin(newText:_coinCounter + "/" + coinsInLevel);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Respawn":
                {
                    RespawnPoint.position = other.transform.Find("Point").position;
                    break;
                }
            case "Finish":
                {
                    string nextLevel = other.GetComponent<LevelGoals>().nextLevel;
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
            case "Coin":
                {
                    _coinCounter++;
                    _playerUIController.UpdateCoin(newText: _coinCounter + "/" + coinsInLevel);
                    Destroy(other.gameObject);
                    break;
                }
            case "Health":
                {
                    if (_health < 3)
                    {
                        Destroy(other.gameObject);
                        _health++;
                        _playerUIController.UpdateHealth(_health, _maxHealth);
                    }
                    break;
                }
            case "Death":
                {
                    _health --;
                    _playerUIController.UpdateHealth(_health, _maxHealth);
                    if (_health <= 0)
                    {
                        string thisLevel = SceneManager.GetActiveScene().name;
                        SceneManager.LoadScene(thisLevel);
         
                    }
                    else
                    {
                        transform.position = RespawnPoint.position;
                    }
                        break;
                }
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
