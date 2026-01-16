using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int health = 3;
    private int maxHealth = 3;
    
    public int coinCounter = 0;
    public string nextLevel = "";
    public Transform respawnPosition;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
                {
                    health--;
                    if (health <= 0)
                    {
                        string thisLevel = SceneManager.GetActiveScene().name;
                        SceneManager.LoadScene(thisLevel);
                    } else {
                        transform.position = respawnPosition.position;
                    }
                        break;
                }
            case "Finish":
                {
                    nextLevel = collision.transform.GetComponent<LevelGoal>().nextLevel;
                    SceneManager.LoadScene(nextLevel);
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
                    if(health < maxHealth)
                    {
                        health++;
                        Destroy(collision.gameObject);
                    }
                    break;
                }
            case "Respawn":
                {
                    respawnPosition = collision.transform.Find("Point");
                    break;
                }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
