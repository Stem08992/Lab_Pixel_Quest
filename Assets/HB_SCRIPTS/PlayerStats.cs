using UnityEngine;
using UnityEngine.SceneManagement;
using static GoalLevels;

public class PlayerStats : MonoBehaviour
{
    public string nextLevel = "";
    public int counter = 0;
    public int health = 100;
    public int maxHealth = 100;
    public Transform RespawnPoint;
    private PlayerUIController playerUIControl;

    // Start is called before the first frame update
    void Start()
    {
        
        playerUIControl = GetComponent<PlayerUIController>();
        playerUIControl.UpdateHealth(health, maxHealth);
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("hit");
        //Debug.Log(collision.tag);

        switch (collision.tag)
        {
            case "Death":
                {

                    health -= 10;
   
                    playerUIControl.UpdateHealth(health, maxHealth);
                    if (health <= 0)
                    {
                        string thisLevel = SceneManager.GetActiveScene().name;
                        SceneManager.LoadScene(thisLevel);
                    }
                    else
                    {
                        string thisLevel = SceneManager.GetActiveScene().name;
                        SceneManager.LoadScene(thisLevel);
                    }
                    break;
                }
            case "Finish":
                {

                    SceneManager.LoadScene(nextLevel);
                    break;
                }
            case "Coin":
                {
                    counter++;
 
                    Destroy(collision.gameObject);
                    break;
                }
            case "Health":
                {
                    if (health < 3)
                    {
                        health++;
 
                        playerUIControl.UpdateHealth(health, maxHealth);
                        Destroy(collision.gameObject);
                    }
                    break;
                }
            case "Respawn":
                {

                    break;
                }
        }
    }
}