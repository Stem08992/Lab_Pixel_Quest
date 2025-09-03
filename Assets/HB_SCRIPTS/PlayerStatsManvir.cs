using UnityEngine;
using UnityEngine.SceneManagement;
using static GoalLevels;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PlayerStatsManvir : MonoBehaviour
{
    public string nextLevel0 = "";
    public int counter0 = 0;
    public int health0 = 100;
    public int maxHealth0 = 100;
    public Transform RespawnPoint0;
    private PlayerUIController playerUIControl0;
    string thisLevel0;
    private int coinsInLevel0 = 0;
    //private AudioController audioController0;

    // Start is called before the first frame update
    void Start()
    {
        thisLevel0 = SceneManager.GetActiveScene().name;
        coinsInLevel0 = GameObject.Find("Coins").transform.childCount;
        playerUIControl0 = GetComponent<PlayerUIController>();
        playerUIControl0.UpdateStress(maxHealth0-health0, maxHealth0);
        playerUIControl0.UpdateCoinText(counter0 + "/" + coinsInLevel0);
        //audioController0 = GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (thisLevel0)
        {
            case "Level_1Seb":
                {
                    nextLevel0 = "(1)MerCutScene";
                    break;
                }

            case "Level_1Mer":
                {
                    nextLevel0 = "(2)SebCutScene";
                    break;
                }
            case "Level_2Seb":
                {
                    nextLevel0 = "(2)MerCutScene";
                    break;
                }

            case "Level_2Mer":
                {
                    nextLevel0 = "(3)SebCutScene";
                    break;
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.tag)
        {
            case "Death":
                {
                    health0 -= 10;
                    playerUIControl0.UpdateStress(maxHealth0 - health0, maxHealth0);
                    //playerUIControl0.UpdateHealth(health0, maxHealth0);
                    if (health0 <= 0)
                    {
                        SceneManager.LoadScene(thisLevel0);
                        //Application.Quit();
                        // SceneManager.UnloadSceneAsync(thisLevel0); // exists scene on death
                    }
                    else
                    {
                        transform.position = RespawnPoint0.position;
                        //SceneManager.LoadScene(thisLevel0);  starts from beginning of level 
                    }
                    break;
                }
                
            case "Finish":
                {
                    SceneManager.LoadScene(nextLevel0);
                    break;
                }
            case "Coin":
                {
                    counter0++;
                    playerUIControl0.UpdateCoinText(counter0 + "/" + coinsInLevel0);
                    Destroy(collision.gameObject);
                    break;
                }

             case "Respawn":
                {
                 //audioController.PlayAudio("checkpoint");
                   RespawnPoint0.position = collision.transform.Find("Point").position;
                   break;
                }
        } // end of switch
    }
}
