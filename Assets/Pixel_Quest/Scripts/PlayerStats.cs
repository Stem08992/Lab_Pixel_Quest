using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public string nextLevel = "GeoLevel_2";
    public int CoinCounter = 0;
    private int _health = 0;
    private int _maxHealth = 3;
    public Transform respawnPoint;
    private void OnTriggerEnter2D(Collider2D other)
    {
        {
            switch (other.tag)
            {
                case "Death":
                    {
                        _health--;
                        if (_health <= 0)
                        {
                            string thisLevel = SceneManager.GetActiveScene().name;
                            SceneManager.LoadScene(thisLevel);
                        }
                        else
                        {
                            transform.position = respawnPoint.position;
                        }
                        break;
                    }
                case "Finish":
                    {
                        string nextLevel = other.transform.GetComponent<LevelGoal>()._nextLevel;
                        SceneManager.LoadScene(nextLevel);
                        break;
                    }
                case "Coin":
                    {
                        CoinCounter++;
                        Destroy(other.gameObject);
                        break;
                    }
                case "Health":
                    {
                        Destroy(other.gameObject);
                        _health++;
                        if (_health < _maxHealth)
                        {
                            Destroy(other.gameObject);
                            _health++;
                        }
                        break;
                        
                    }
            }
        }

    }
}
