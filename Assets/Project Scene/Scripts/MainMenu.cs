using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // PANELS
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public UnityEngine.UI.Image dimOverlay;

    // Called when Play button is pressed
    public void PlayGame()
    {
        SceneManager.LoadScene("Midgard");
    }

    // Open Options menu
     public void OpenOptions()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
        // Dim the background
        if (dimOverlay != null)
            dimOverlay.color = new Color(0, 0, 0, 0.5f); // semi-transparent black
    }

    // Close Options menu
    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        mainPanel.SetActive(true);
        // Restore background
        if (dimOverlay != null)
            dimOverlay.color = new Color(0, 0, 0, 0f); // fully transparent
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit"); // Works in editor only
    }
}
