using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public string nextLevel;
   public  void LoadLevel()


    {
        SceneManager.LoadScene(nextLevel);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }







}
