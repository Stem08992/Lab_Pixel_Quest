using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndAI : MonoBehaviour
{
    private GameManager _gameManager;
    public ShopMenu shopMenu;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (_gameManager.coinCount > 0)
            {
                shopMenu.MenuOnOff(true);
            }
            else
            {
                shopMenu.MenuOnOff(false);
            }

            string thisLevel = "Level 1";
            SceneManager.LoadScene(thisLevel);
        }
    }
}
