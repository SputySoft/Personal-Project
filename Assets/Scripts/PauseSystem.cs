using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
    }
}