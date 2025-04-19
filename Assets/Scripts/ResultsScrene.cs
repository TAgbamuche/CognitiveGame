// connected to gridmanager and UIManger in game scene to calculate stats of the player.
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class ResultsScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI accuracyText;
    public TextMeshProUGUI timeText;
    public GameObject achievementPanel;
    public TextMeshProUGUI achievementText;
    public GameObject graphPointPrefab;
    public Transform graphContainer;

    void Start()
    {
        ShowStats();
        ShowAchievements();
        DrawGraph();
    }

    void ShowStats()
    {
        scoreText.text = "Score: " + GameStats.Instance.totalScore;
        timeText.text = "Time: " + Mathf.RoundToInt(GameStats.Instance.totalTime) + "s";

        float accuracy = (GameStats.Instance.totalAttempts == 0) ? 0f :
            ((float)GameStats.Instance.totalMatches / GameStats.Instance.totalAttempts) * 100f;

        accuracyText.text = $"Accuracy: {accuracy:F1}%";
    }

    void ShowAchievements()
    {
        achievementText.text = "";

        if (GameStats.Instance.totalMatches >= 3)
            achievementText.text += "🏆 3-Times Matcher\n";

        if (GameStats.Instance.totalScore >= 60)
            achievementText.text += "💪 Rescuer\n";

        if (achievementText.text == "")
            achievementText.text = "No achievements this time.";
    }

    void DrawGraph()
    {
        var times = GameStats.Instance.timePoints;
        var scores = GameStats.Instance.scoreOverTime;

        if (times.Count < 2) return;

        float graphWidth = 400f;
        float graphHeight = 200f;
        float maxTime = times.Max();
        float maxScore = scores.Max();

        for (int i = 0; i < times.Count; i++)
        {
            float xPos = (times[i] / maxTime) * graphWidth;
            float yPos = (scores[i] / (float)maxScore) * graphHeight;

            GameObject point = Instantiate(graphPointPrefab, graphContainer);
            point.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos);
        }
    }
}

