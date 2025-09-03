using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats1 : MonoBehaviour
{
    //public string nextLevel = "GeoLevel_2"
    public int _coinCounter = 0;
    public int _health = 100;
    public int _maxHealth = 100;
    private PlayerUIController _playerUIController;
    private int coinsInLevel = 0;
    public string nextLevel0 = "";
        public string thisLevel;

    private void Start1()
    {
        _playerUIController = GetComponent<PlayerUIController>();
        _playerUIController.UpdateHealth(_health, _maxHealth);

        coinsInLevel = GameObject.Find("Coins").transform.childCount;
        _playerUIController.UpdateCoinText(newText:_coinCounter + "/" + coinsInLevel);

        switch(thisLevel)
        {
            case "Level_1Mer":
                    {
                        nextLevel0 = "Level_2Mer";
                        break;
                    }
            case "Level_1Seb":
                {
                    nextLevel0 = "Level_2SEb";
                    break;
                }
        }
    }

    private void OnTriggerEnter2D0(Collider2D other)
    {
        switch (other.tag)
        {
            case "Finish":
                {
                    SceneManager.LoadScene(nextLevel0);
                    break;
                }
            case "Coin":
                {
                    _coinCounter++;
                    _playerUIController.UpdateCoinText(newText: _coinCounter + "/" + coinsInLevel);
                    Destroy(other.gameObject);
                    break;
                }
            case "Health":
                {
                    if (_health < 100)
                    {
                        Destroy(other.gameObject);
                        _health+=10;
                        _playerUIController.UpdateHealth(_health, _maxHealth);
                    }
                    break;
                }
            case "Death":
                {
                    _health -= 10;
                    _playerUIController.UpdateHealth(_health, _maxHealth);
                    if (_health <= 0)
                    {
                        string thisLevel = SceneManager.GetActiveScene().name;
                        SceneManager.LoadScene(thisLevel);
         
                    }
                    else
                    {
                        
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
