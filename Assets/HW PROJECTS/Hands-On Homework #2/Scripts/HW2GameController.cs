using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HW2GameController: MonoBehaviour
{
    // Score 
    public TextMeshProUGUI scoreText;
    private int score = 0;

    // Updates the score and UI 
    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString(); 
    }
  
    // Reload the current scene 
    public void ReloadLevel() {   SceneManager.LoadScene(SceneManager.GetActiveScene().name);}
}
