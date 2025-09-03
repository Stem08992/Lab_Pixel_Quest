using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Constants
    public const float MAX_BAR = 500f;

    // === Persistent Game Data ===
    public int score = 500;

    // Bar values (out of 500)
    public float popularity = 150f; // happiness
    public float traffic = 250f;
    public float pollution = 250f;
    public float revenue = 0f;

    // Time
    public int month = 7;
    public int year = 2025;

    // Time tracking for mid-year/quarterly decisions
    public int halfYearCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // === Update Game Stats ===
    public void AddScore(int value)
    {
        score += value;
    }

    public void UpdateBarValues(float popularityDelta, float trafficDelta, float pollutionDelta, float revenueDelta)
    {
        popularity = Mathf.Clamp(popularity + popularityDelta, 0f, MAX_BAR);
        traffic = Mathf.Clamp(traffic + trafficDelta, 0f, MAX_BAR);
        pollution = Mathf.Clamp(pollution + pollutionDelta, 0f, MAX_BAR);
        revenue = Mathf.Clamp(revenue + revenueDelta, 0f, MAX_BAR);
    }

    public void SetBarValues(float popularity, float traffic, float pollution, float revenue)
    {
        this.popularity = Mathf.Clamp(popularity, 0f, MAX_BAR);
        this.traffic = Mathf.Clamp(traffic, 0f, MAX_BAR);
        this.pollution = Mathf.Clamp(pollution, 0f, MAX_BAR);
        this.revenue = Mathf.Clamp(revenue, 0f, MAX_BAR);
    }

    // === Time System ===
    public void AdvanceMonth()
    {
        if (month == 12)
        {
            month = 1;
            year++;
        }
        else
        {
            month++;
        }

        halfYearCount++;
    }

    // === Dialogue Feedback ===
    public string GetScoreFeedback()
    {
        if (score >= 750)
            return "You're doing great! The city is thriving.";
        else if (score <= 200)
            return "You're doing horribly. People are calling for your resignation.";
        else
            return "You’re doing okay, but the pressure’s mounting.";
    }

    public string GetBarPerformanceFeedback()
    {
        float p = popularity / MAX_BAR;
        float t = traffic / MAX_BAR;
        float pol = pollution / MAX_BAR;
        float r = revenue / MAX_BAR;

        if (p >= 0.7f && t <= 0.3f && pol <= 0.3f && r >= 0.6f)
        {
            return "You're doing fantastic! The city is cleaner, happier, and more efficient!";
        }
        else if (p <= 0.3f || t >= 0.7f || pol >= 0.7f)
        {
            return "Things are going badly. Traffic and pollution are out of control.";
        }
        else
        {
            return "You’re holding things together, but there’s a long way to go.";
        }
    }

    public string GetBarSummary()
    {
        return $"?? City Report:\n" +
               $"Popularity: {(int)(popularity / MAX_BAR * 100)}%\n" +
               $"Traffic: {(int)(traffic / MAX_BAR * 100)}%\n" +
               $"Pollution: {(int)(pollution / MAX_BAR * 100)}%\n" +
               $"Revenue: ${(int)(revenue)}M";
    }
}
