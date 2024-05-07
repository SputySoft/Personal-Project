using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_Menu : MonoBehaviour
{
    private GameObject pauseMenuUI;

    private void Start()
    {
        pauseMenuUI = gameObject;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }


}
