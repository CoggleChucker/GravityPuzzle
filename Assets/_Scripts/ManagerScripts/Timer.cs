using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    #region Singleton
    public static Timer instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    #endregion /Singleton

    public float startTime = 120f;

    public TextMeshProUGUI timerText;

    private float currentTime;

    private bool timerRunning = false;

    private void Start()
    {
        GameEvents.OnGameOver += PauseTimer;
        GameEvents.OnGameWin += PauseTimer;
        GameEvents.OnGameStart += ResumeTimer;

        currentTime = startTime;

        UpdateTimerUI();
    }

    private void OnDestroy()
    {
        GameEvents.OnGameOver -= PauseTimer;
        GameEvents.OnGameWin -= PauseTimer;
        GameEvents.OnGameStart -= ResumeTimer;
    }
    private void Update()
    {
        if (!timerRunning)
            return;

        currentTime -= Time.deltaTime;

        // Clamp at 0
        if (currentTime <= 0f)
        {
            currentTime = 0f;
            timerRunning = false;

            //Debug.Log("Game over");
            GameEvents.OnGameOver?.Invoke();
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);

        int seconds = Mathf.FloorToInt(currentTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void PauseTimer()
    {
        timerRunning = false;
    }

    public void ResumeTimer()
    {
        timerRunning = true;
    }
}