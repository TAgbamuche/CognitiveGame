
//currently manages game timing

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI GameTimer;
    public float timeRemaining = 120f; // 2 minutes
    private bool isTimerRunning = false;

    public GridManager gridManager; // Set in Inspector

    void Start()
    {
        //StartTimer();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timeRemaining -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            GameTimer.text = $"Time: {minutes:00}:{seconds:00}";

            if (timeRemaining <= 0)
            {
                isTimerRunning = false;
                timeRemaining = 0;
                GameTimer.text = "Game Over!";
                GameOver();
            }
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
        timeRemaining = 120f;
    }

    public void GameOver()
    {
        GameTimer.text = "Time's up!";
        gridManager.HandleGameOver(); // Notify GridManager
       // Invoke(nameof(RestartGame), 2f);
        GameStats.Instance.totalTime = 120f - timeRemaining; //calculates total time taken
        SceneManager.LoadScene("ResultScene"); //load result scene

    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }
}
