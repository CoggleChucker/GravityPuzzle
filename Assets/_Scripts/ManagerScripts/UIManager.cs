using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Transform[] uiScreens;

    private void Start()
    {
        GameEvents.OnGameOver += ActivateGameOverUI;
        GameEvents.OnGameWin += ActivateGameWinUI;
    }

    private void OnDestroy()
    {
        GameEvents.OnGameOver -= ActivateGameOverUI;
        GameEvents.OnGameWin -= ActivateGameWinUI;
    }

    public void DeactivateAllScreens()
    {
        foreach (Transform screen in uiScreens)
        {
            screen.gameObject.SetActive(false);
        }
    }

    public void ActivateUI(int index)
    {
        DeactivateAllScreens();
        if (index >= 0 && index < uiScreens.Length)
        {
            uiScreens[index].gameObject.SetActive(true);
        }
    }


    private void ActivateGamePlayUI()
    {
        ActivateUI(0);
    }

    private void ActivateGameOverUI()
    {
        ActivateUI(1);
    }

    private void ActivateGameWinUI()
    {
        ActivateUI(2);
    }

    public void StartGame()
    {
        GameEvents.OnGameStart?.Invoke();
        ActivateGamePlayUI();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
