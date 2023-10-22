using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject optionMenuUI;
    public GameObject creditUI;
    public GameObject tipsUI;
    public GameObject exitUI;

    public void Start()
    {
        optionMenuUI.SetActive(false);
        creditUI.SetActive(false);
        tipsUI.SetActive(false);
        exitUI.SetActive(false);
    }

    public void ResetLevel()
    {
        // Menghapus PlayerPrefs untuk StarRateLevel1, StarRateLevel2, dan StarRateLevel3
        PlayerPrefs.DeleteKey("StarRateTestLevel");
        PlayerPrefs.DeleteKey("StarRateTutorial");
        PlayerPrefs.DeleteKey("StarRateLevel1");
        PlayerPrefs.DeleteKey("StarRateLevel2");
        PlayerPrefs.DeleteKey("StarRateLevel3");
        PlayerPrefs.Save();
    }
    public void Reset()
    {
        // Mengulang permainan/scene dengan memuat ulang scene saat ini
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void Loading()
    {
        // Menjalankan fungsi PlayBtn dengan penundaan 1 detik
        Invoke("PlayBtn", 1.0f);
    }

    public void PlayBtn()
    {
        SceneManager.LoadScene("Level Choice");
    }

    public void ExitGame()
    {
        // Menutup aplikasi atau permainan
        Application.Quit();
    }


    public void onOption()
    {
        optionMenuUI.SetActive(true);
    }

    public void offOption()
    {
        optionMenuUI.SetActive(false);
    }

    public void onCredit()
    {
        creditUI.SetActive(true);
    }

    public void offCredit()
    {
        creditUI.SetActive(false);
    }

    public void onTips()
    {
        tipsUI.SetActive(true);
    }

    public void offTips()
    {
        tipsUI.SetActive(false);
    }

    public void onExit()
    {
        exitUI.SetActive(true);
    }

    public void offExit()
    {
        exitUI.SetActive(false);
    }
}
