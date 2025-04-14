using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    public void OnStartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }  
    public void OnExitClick()
    {
 
        UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();

    }

}

