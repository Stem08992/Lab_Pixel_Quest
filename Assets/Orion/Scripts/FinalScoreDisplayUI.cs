using UnityEngine;
using TMPro;

public class FinalScoreWorldDisplay : MonoBehaviour
{
    public TextMeshPro scoreText; // Assign in Inspector (not TextMeshProUGUI!)

    private void Start()
    {
        if (GameManager.Instance == null || scoreText == null)
        {
            Debug.LogWarning("FinalScoreWorldDisplay: Missing GameManager or TextMeshPro reference.");
            return;
        }

        int finalScore = CalculateCombinedScore();
        scoreText.text = $"Final Score: {finalScore}";
    }

    private int CalculateCombinedScore()
    {
        float popularityWeight = 1.0f;
        float trafficWeight = -0.5f;
        float pollutionWeight = -0.5f;
        float revenueWeight = 0.8f;

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