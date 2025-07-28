using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuController : MonoBehaviour
{
    public string NextLevel;
    public void Exit()
    {
        Application.Quit();




    }


    public void GameMenu()
    {
        SceneManager.LoadScene(NextLevel);








    }






}
