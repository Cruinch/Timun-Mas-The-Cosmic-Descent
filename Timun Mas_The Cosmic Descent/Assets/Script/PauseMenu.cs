using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    public void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void RestarPause()
    {
        // Mengulang permainan/scene dengan memuat ulang scene saat ini
        Time.timeScale = 1f;
        isPaused = false;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void LevelChoice()
    {
        SceneManager.LoadScene("Level Choice");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

