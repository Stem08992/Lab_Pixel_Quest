using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string _nextLevel;

    public void LoadLevel()
    {
        SceneManager.LoadScene(_nextLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public string Credits;

    public void LoadCredits()
    {
        SceneManager.LoadScene(Credits);
    }



}//