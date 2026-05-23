using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Singleton
    public static ScoreManager instance;
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

    public int currentScore = 0;

    [SerializeField]
    private int maxScrore;

    public void AddCoinToMaxScore()
    {
        maxScrore++;
    }

    public void CoinCollected()
    {
        currentScore++;
        if (currentScore >= maxScrore)
        {
            GameEvents.OnGameWin?.Invoke();
        }
    }
}
