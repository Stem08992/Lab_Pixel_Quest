using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public float levelDuration = 45f;
    private float timeRemaining;
    private bool levelCompleted = false;

    public TMP_Text timerText;

    private bool isLevel3 = false;

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        // Enable timer only if in Level3
        if (currentScene == "L3")
        {
            isLevel3 = true;
            timeRemaining = levelDuration;
        }
        else
        {
            this.enabled = false; // Disable script on other scenes
        }
    }

    void Update()
    {
        if (!isLevel3 || levelCompleted)
            return;

        timeRemaining -= Time.deltaTime;
        timeRemaining = Mathf.Max(0, timeRemaining);

        UpdateTimerDisplay();

        if (timeRemaining <= 0)
        {
            ReloadLevel();
        }
    }

    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CompleteLevel()
    {
        if (isLevel3)
        {
            levelCompleted = true;
            Debug.Log("Level completed in time!");
            // Optional: Go to end screen or next level here
        }
    }
}

