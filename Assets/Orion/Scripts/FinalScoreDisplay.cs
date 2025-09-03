using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScoreDisplay : MonoBehaviour
{
    public string winSceneName = "WinScene";     // Assign in Inspector or set here
    public string loseSceneName = "LoseScene";   // Assign in Inspector or set here

    private void Start()
    {
        // Only run this if the scene is "Problem 7"
        if (SceneManager.GetActiveScene().name == "Problem 7")
        {
            int finalScore = CalculateCombinedScore();

            if (finalScore > 750)
            {
                SceneManager.LoadScene(winSceneName);
            }
            else
            {
                SceneManager.LoadScene(loseSceneName);
            }
        }
    }

    private int CalculateCombinedScore()
    {
        // Scoring weights
        float popularityWeight = 1.0f;
        float trafficWeight = -0.5f;
        float pollutionWeight = -0.5f;
        float revenueWeight = 0.8f;

        // Access values from GameManager
        var gm = GameManager.Instance;

        float combinedScore =
            (gm.popularity * popularityWeight) +
            (gm.traffic * trafficWeight) +
            (gm.pollution * pollutionWeight) +
            (gm.revenue * revenueWeight);

        combinedScore = Mathf.Clamp(combinedScore, 0f, 1000f);

        return Mathf.RoundToInt(combinedScore);
    }
}