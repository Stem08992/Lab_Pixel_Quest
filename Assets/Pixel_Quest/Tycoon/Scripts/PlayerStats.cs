using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerStats : MonoBehaviour
{
    //public string nextLevel = "GeoLevel_2";
    public int money = 0;
    
    
    public Transform RespawnPoint;
    
    public PlayerUIController _playerUIController;
    
    // Start is called before the first frame update

    private void Start()
    {
        _playerUIController = GetComponent<PlayerUIController>();
       
        _playerUIController.StartUI();
        
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag) 
        {


            case "Money":
                {
                    money+=other.GetComponent<MoneyGiver>().Givemoney();
                    break;
                }







           





            case "Finish":
                {
                    string Nextlevel = other.GetComponent<LevelGoal>().Nextlevel;
                  SceneManager.LoadScene(Nextlevel); break; }


           
           





        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "barrier")
        {
            if (money >=collision.collider.GetComponent<LevelUnlock>().cost)
            {
                Destroy(collision.collider.gameObject);
                money-=collision.collider.GetComponent<LevelUnlock>().cost;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
