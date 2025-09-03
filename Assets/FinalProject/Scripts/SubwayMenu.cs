using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubwayMenu : MonoBehaviour
{
    public string startScene;

    public void LoadLevel()
    {
        SceneManager.LoadScene(startScene);
    }

    public void LoadHowToPlay()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Opening Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

   
}
