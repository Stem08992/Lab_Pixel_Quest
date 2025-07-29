using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string nextLevel;
    
    public void LoadLevel()
    {

        SceneManager.LoadScene(nextLevel);






    }
     public void QuitGame()
    {
       Application.Quit();


    }





}
