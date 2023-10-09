using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public void TestLevel()
    {
        SceneManager.LoadScene("Test Level");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("");
    }

    public void Level1()
    {
        SceneManager.LoadScene("");
    }

    public void Level2()
    {
        SceneManager.LoadScene("");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Boss Level");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
