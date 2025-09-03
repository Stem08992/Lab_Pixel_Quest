using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class CountdownGameOver : MonoBehaviour
{
    public float totalTime = 10f;           // Set countdown time in seconds
    public Text timerText;                  // Reference to UI Text displaying time
    public GameObject gameOverScreen;       // UI panel to show when time is up

    private float currentTime;

    void Start()
    {
        currentTime = totalTime;
        gameOverScreen.SetActive(false); // Hide Game Over screen at start
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timerText.text = Mathf.Ceil(currentTime).ToString(); // Round up display
        }
        else
        {
            timerText.text = "0";
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        gameOverScreen.SetActive(true); // Show Game Over screen
        Time.timeScale = 0f;            // Pause game (optional)
    }
    


}

