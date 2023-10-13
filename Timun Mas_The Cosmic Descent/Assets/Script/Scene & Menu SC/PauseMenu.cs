using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject optionMenuUI;

    private bool isPaused = false;

    public void Start()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        optionMenuUI.SetActive(false);
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

    public void onOption()
    {
        pauseMenuUI.SetActive(false);
        optionMenuUI.SetActive(true);
    }

    public void offOption()
    {
        optionMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

