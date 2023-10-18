using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject LoadingPanel;

    public void GoScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(string sceneName)
    {
        LoadingPanel.SetActive(true);
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        // Tambahkan penundaan selama misalnya 2 detik sebelum memulai loading
        yield return new WaitForSeconds(2.0f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);


        while (operation != null)
        {
            yield return null;
        }

        LoadingPanel.SetActive(true);
    }

/*    public void LTestLevel()
    {
        LoadingPanel.SetActive(true);
        // Menjalankan fungsi PlayBtn dengan penundaan 1 detik
        Invoke("TestLevel", 3.0f);  
    }

    public void LLevel3()
    {
        LoadingPanel.SetActive(true);
        // Menjalankan fungsi PlayBtn dengan penundaan 1 detik
        Invoke("Level3", 3.0f);
    }*/



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
