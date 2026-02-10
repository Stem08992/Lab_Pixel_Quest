
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform respawnPoint;
    private int coinCounter = 0;
    private int _health = 3;
    private int _maxHealth = 3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
                {
                    _health--;
                    if (_health <= 0)
                        {
                            string thisLevel = SceneManager.GetActiveScene().name;
                            SceneManager.LoadScene(thisLevel);
                            _health = _maxHealth;

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
                    Destroy(collision.gameObject);
                    break;
                }
            case "Health":
                {
                    if (_health < _maxHealth)
                    {
                        Destroy(collision.gameObject);
                        _health++;
                    }
                    
                    break;
                }
            case "Finish":
                {
                    string nextLevel = collision.transform.GetComponent < LevelGoal > ().nextLevel;
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
           

        }

    }
}
