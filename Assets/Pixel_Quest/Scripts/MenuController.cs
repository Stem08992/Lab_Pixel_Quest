using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public string nextlevel;
    public GameObject ShopPanel;

    public void OpenShopPanel()
    {
        ShopPanel.SetActive(true);
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(nextlevel);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void CloseShopPanel()
    {
        ShopPanel.SetActive(false);
    }

}
