using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class stat : MonoBehaviour
{
    public Transform respawn;
    public string nextLevel = "Scene_2";
    private int coinsinlevel = 0;
    private int counter = 0;
    private int health = 3;
    private int maxhealth = 3;
    private PlayerUI playerUI;
    public TextMeshPro text;
    public TextMeshProUGUI uitext;
    private Audios audio;
    // Start is called before the first frame update
    private void Start()
    {   
        coinsinlevel = GameObject.Find("Coins").transform.childCount;
        playerUI= GetComponent<PlayerUI>();
        playerUI.UpdateHealth(health, maxhealth);
        playerUI.UpdateCoin(counter + "/" + coinsinlevel);
        audio=GetComponent<Audios>();
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
                    health--;
                    playerUI.UpdateHealth(health, maxhealth);
                    if (health <= 0)
                    {
                        audio.playaudio("Death");
                        string thisLevel = SceneManager.GetActiveScene().name;
                        SceneManager.LoadScene(thisLevel);
                    }
                    else
                    {
                        transform.position = respawn.position;
                    }
                    break;
                }
            case "Finish":
                {
                    string nextLevel = collision.GetComponent<LevelGoal>().Nextlevel;
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
            case "Coin":
                {
                    audio.playaudio("Coins");
                    counter++;
                    playerUI.UpdateCoin(counter + "/" + coinsinlevel);
                    Destroy(collision.gameObject);
                    break;
                }
            case "Health":
                {

                    if (health < 3)
                    {
                        audio.playaudio("Heart");
                        health++;
                        playerUI.UpdateHealth(health, maxhealth);    
                        Destroy(collision.gameObject);
                    }
                    break;
                }
            case "Respawn":
                {
                    audio.playaudio("Checkpoint");
                    respawn.position = collision.transform.Find("Point").position; 
                break;
                }
        }
        Debug.Log("Hit");
    }
}
