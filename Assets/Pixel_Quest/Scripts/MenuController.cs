using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public string nextlevel;
    public void LoadLevel()
    {
        SceneManager.LoadScene(nextlevel);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
