using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public GameObject Menu;
    private GameManager _gameManager;
    public PlayerMov Movement; 
    private int chassisCost = 10;
    public Sprite Sprite;
    public Sprite SpriteUpgrade1;
    public Sprite SpriteUpgrade2;
    private GameObject _upgradeBtn;
    public TextMeshProUGUI coinTextGlobalUpgrade;
    public TextMeshProUGUI upgradeCounter;
    public TextMeshProUGUI speedCounter;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _gameManager = GameManager.Instance;
        _upgradeBtn = GameObject.Find("Chassis Upgrade");
        coinTextGlobalUpgrade.text = "Coins: " + _gameManager.coinCount;

        if (_gameManager.coinCount < chassisCost)
        {
            UnityEngine.UI.Button upgradeBtn = _upgradeBtn.GetComponent<UnityEngine.UI.Button>();
            if (upgradeBtn != null)
            {
                upgradeBtn.interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade(string type)
    {
        switch (type)
        {
            case "chassis":
                if (_gameManager.coinCount >= chassisCost)
                {
                    // Get the Button component attached to it
                    UnityEngine.UI.Button upgradeBtn = _upgradeBtn.GetComponent<UnityEngine.UI.Button>();
                    
                    //Enable the button just in case it was disabled
                    if (upgradeBtn != null)
                    {
                        upgradeBtn.interactable = true;
                    }

                    // Update the global coin count
                    _gameManager.SubtractCoins(chassisCost);

                    // Update the global coin count text
                    coinTextGlobalUpgrade.text = "Coins: " + _gameManager.coinCount;

                    if (Movement.speed == 10)
                    {
                        Movement.UpgradeTrain(5, SpriteUpgrade1);

                        // Update the speed counter text
                        speedCounter.text = "Speed: 15/25";
                        // Update the upgrade counter text
                        upgradeCounter.text = "1/2";

                    } 
                    else if (Movement.speed == 15)
                    {
                        Movement.UpgradeTrain(10, SpriteUpgrade2);

                        // Update the speed counter text
                        speedCounter.text = "Speed: 25/25";
                        // Update the upgrade counter text
                        upgradeCounter.text = "2/2";
                    }

                    if (_gameManager.coinCount < chassisCost || Movement.speed == 25)
                    {
                        if (upgradeBtn != null)
                        {
                            upgradeBtn.interactable = false;
                        }
                    }
                }
                break;
        }
    }

    public void MenuOnOff(bool isOn)
    {
        Menu.SetActive(isOn);
    }
}
