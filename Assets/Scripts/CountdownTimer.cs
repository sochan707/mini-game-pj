using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float durationSeconds = 120f;

    TMP_Text timerText;
    float timeRemaining;

    void Awake()
    {
        timerText = GetComponent<TMP_Text>();
        timeRemaining = durationSeconds;
        UpdateDisplay();
    }

    void Update()
    {
        if (timeRemaining <= 0f) return;

        timeRemaining = Mathf.Max(0f, timeRemaining - Time.deltaTime);
        UpdateDisplay();

        if (timeRemaining <= 0f)
        {
            EndGameController.PlayerWon = false;
            SceneManager.LoadScene("EndGame");
        }
    }

    void UpdateDisplay()
    {
        int seconds = Mathf.CeilToInt(timeRemaining);
        timerText.text = $"{seconds / 60:00}:{seconds % 60:00}";
    }
}
