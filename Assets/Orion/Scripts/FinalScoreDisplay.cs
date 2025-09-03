using UnityEngine;
using TMPro;

public class FinalScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI resultText; // Assign this in the Inspector

    private void Start()
    {
        if (GameManager.Instance == null || resultText == null)
        {
            Debug.LogWarning("FinalScoreDisplay: Missing GameManager instance or resultText UI reference.");
            return;
        }

        int finalScore = GameManager.Instance.score;

        if (finalScore > 750)
        {
            resultText.text = $"🎉 Congratulations! You Win!\nScore: {finalScore}";
        }
        else
        {
            resultText.text = $"❌ You Have Failed!\nScore: {finalScore}";
        }
    }
}