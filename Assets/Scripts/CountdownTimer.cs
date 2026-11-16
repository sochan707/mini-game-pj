using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public float durationSeconds = 180f;

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
    }

    void UpdateDisplay()
    {
        int seconds = Mathf.CeilToInt(timeRemaining);
        timerText.text = $"{seconds / 60:00}:{seconds % 60:00}";
    }
}