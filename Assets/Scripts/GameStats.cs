using UnityEngine;
using System.Collections.Generic;

public class GameStats : MonoBehaviour
{
    public static GameStats Instance;

    public int totalScore = 0;
    public int totalMatches = 0;
    public int totalAttempts = 0;
    public float totalTime = 0f;

    public List<float> timePoints = new List<float>(); // Timestamps for graph
    public List<int> scoreOverTime = new List<int>();  // Score at each timestamp

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RecordPoint(float time, int score)
    {
        timePoints.Add(time);
        scoreOverTime.Add(score);
    }

    public void ResetStats()
    {
        totalScore = 0;
        totalMatches = 0;
        totalAttempts = 0;
        totalTime = 0f;
        timePoints.Clear();
        scoreOverTime.Clear();
    }
}

