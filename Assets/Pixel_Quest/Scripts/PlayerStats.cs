using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public string nextLevel = "GeoLevel_2";
    private int coinCounter = 0;
    private int _health = 3;
    private int maxHealth = 3;
    public Transform RespawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Coin":
                {
                    coinCounter++;
                    Destroy(collision.gameObject);
                    break;
                }
            case "Death":
                {

                    _health--;
                    if (_health == 0)
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

            case "Finish":
                {
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
            case "Health":
                        {
                            _health++;
                            Destroy(collision.gameObject);
                    break;
                        }

             case "Respawn":
                  {
                            RespawnPoint.position =collision.transform.Find("Point").position;

                                    break;  
                  }
               
        }
    }
    
}

