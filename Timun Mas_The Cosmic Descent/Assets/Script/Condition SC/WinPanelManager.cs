using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanelManager : MonoBehaviour
{
    public GameObject winPanel;
    public Text winScoreText;
    public Image starImage1;
    public Image starImage2;
    public Image starImage3;
    private int score;

    private void Start()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    public void ShowWinPanel()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        score = ScoreManager.instance.GetScore();
        if (winScoreText != null)
        {
            winScoreText.text = "Score: " + score.ToString();
        }

        int starRate = CalculateStarRate(score);

        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Test Level")
        {
            PlayerPrefs.SetInt("StarRateTestLevel", starRate);
        }
        else if (currentSceneName == "Tutorial")
        {
            PlayerPrefs.SetInt("StarRateTutorial", starRate);
        }
        else if (currentSceneName == "Level1")
        {
            PlayerPrefs.SetInt("StarRateLevel1", starRate);
        }
        else if (currentSceneName == "Level2")
        {
            PlayerPrefs.SetInt("StarRateLevel2", starRate);
        }
        else if (currentSceneName == "Boss Level")
        {
            PlayerPrefs.SetInt("StarRateLevel3", starRate);
        }

        PlayerPrefs.Save();

        if (starImage1 != null)
        {
            starImage1.gameObject.SetActive(starRate >= 1);
        }
        if (starImage2 != null)
        {
            starImage2.gameObject.SetActive(starRate >= 2);
        }
        if (starImage3 != null)
        {
            starImage3.gameObject.SetActive(starRate == 3);
        }
    }

    private int CalculateStarRate(int score)
    {
        if (score >= 300)
        {
            return 3;
        }
        else if (score >= 200)
        {
            return 2;
        }
        else if (score >= 100)
        {
            return 1;
        }
        return 0;
    }
}
