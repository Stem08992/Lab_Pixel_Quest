using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;





public class MenuScript : MonoBehaviour
{
    public TextMeshProUGUI PLAYText;
    public TextMeshProUGUI EXITText;

    void Start()
    {
        PLAYText.text = "PLAY";
        EXITText.text = "EXIT";
    }
    public void OnPlayButton()
    {

        Debug.Log("Play button clicked.");
        SceneManager.LoadScene("L1");
    }

    public void OnExitButton()
    {
        Debug.Log("Exit button clicked.");
        Application.Quit();


        
        

    }
}      










