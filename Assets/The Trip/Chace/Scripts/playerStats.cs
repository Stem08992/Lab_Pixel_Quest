using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int coinCount = 0;
    private int coinLevelCount = 0;
    public int playerLife = 0;
    public int playerMaxLife = 3;
    public Transform respawnPoint;
    public string nextLevel = "Scene_2";
    private UIController UIController;
    // Start is called before the first frame update
    void Start()
    {
        coinLevelCount = GameObject.Find("Coins").transform.childCount;
        playerLife = playerMaxLife;
        UIController = GetComponent<UIController>();
        UIController.StartUI();
        UIController.UpdateHealth(playerLife, playerMaxLife);
        UIController.UpdateText(coinCount + "/" + coinLevelCount);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.tag)
        {
            case "Death":
                {
                    playerLife--;
                    if (playerLife <= 0)
                    {
                        string thisLevel = SceneManager.GetActiveScene().name;
                        SceneManager.LoadScene(thisLevel);
                    }
                    else
                    {
                        transform.position = respawnPoint.position;
                    }
                    UIController.UpdateHealth(playerLife, playerMaxLife);




                    Debug.Log("Hit");
                    break;
                }
            case "Finish":
                {
                 
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
            case "Coin":
                {
                    coinCount++;
                    UIController.UpdateText(coinCount + "/" + coinLevelCount);
                    Destroy(collision.gameObject);
                    break;
                }
            case "Heart":
                {
                    if (playerLife < playerMaxLife)
                    {
                        playerLife++;
                        Destroy(collision.gameObject);
                        UIController.UpdateHealth(playerLife, playerMaxLife);
                    }

                    break;
                }
            case "Respawn":

                {
                    respawnPoint.position = collision.transform.position;
                    break;
                }

        }

    }
}
