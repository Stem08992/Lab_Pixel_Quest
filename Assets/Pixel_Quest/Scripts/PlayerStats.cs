using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public string nextLevel = "Scene_2";
    public int coinCounter = 0;
    public int health = 3;
    public Transform RespawnPoint;
    private PlayerUIController playerUIController;
    public int CoinsInLevel = 0;
    // Start is called before the first frame update

    private void Start()
    {
        playerUIController=GetComponent<PlayerUIController>();
        playerUIController.UpdateHealth(health, 3);
        CoinsInLevel = GameObject.Find("Coin").transform.childCount;
        playerUIController.UpdateText(coinCounter + "/" + CoinsInLevel);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);
        switch (collision.tag)
        {
            case "Respawn":
                {
                    RespawnPoint = collision.transform;
                    break;
                }
            case "Death":
                {
                    health--;
                    playerUIController.UpdateHealth(health, 3);
                    if (health <= 0)
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
                    string nextLevel = collision.transform.GetComponent<LevelScript>().nextLevel;
                    SceneManager.LoadScene(nextLevel);
                    break;

                }
            case "Coin":
                {
                    coinCounter++;
                    playerUIController.UpdateText(coinCounter + "/" + CoinsInLevel);
                    Destroy(collision.gameObject);
                    break;
                }
            case "Health":
                {
                    
                    if (health < 3)
                    {
                        health++;
                        playerUIController.UpdateHealth(health, 3);
                        Destroy(collision.gameObject); 

                    }   
                    break;
                }


        }
    }
}
