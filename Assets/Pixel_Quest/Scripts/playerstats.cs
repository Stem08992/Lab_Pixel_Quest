using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class publicstats : MonoBehaviour
{
    public string nextlevel = "pq2";
    public int CoinCounter = 0;
    public int health = 3;
    public int maxhealth = 3;
    public Transform respawnPoint;
    private PlayerUI _PlayerUI;
    public TextMeshProUGUI textUI;
    public int CoinsInLevel = 0;

    private void Start()
    {
        _PlayerUI = GetComponent<PlayerUI>();
        _PlayerUI.UpdateHealth(health, maxhealth);        
        CoinsInLevel = GameObject.Find("Coins").transform.childCount;
      //_PlayerUI.UpdateText(CoinCounter + "/" + CoinsInLevel);          // throw new NotImplemen

       
    }    

    private void OnTriggerEnter2D(Collider2D other)


    {
        switch (other.tag)
        {
            case "Death":
                {
                    string thislevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thislevel);

                    break;




                }

            case "Finish":
                {
                    SceneManager.LoadScene(nextlevel);
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
                    health++;
                    _PlayerUI.UpdateHealth(health, maxhealth);



                    Destroy(other.gameObject);
                    break;
                }


            case "Respawn":
                {
                    respawnPoint.position = other.transform.Find("point").position;
                    break;
                }
        }
    }
}


         
                 
