using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject LoadingPanel;

    public void LoadScene(string sceneName)
    {
        //LoadingPanel.SetActive(true);
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        if (LoadingPanel != null)
        {
            LoadingPanel.SetActive(true);
        }

        // Tambahkan penundaan selama misalnya 2 detik sebelum memulai loading
        yield return new WaitForSeconds(2.0f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);


        while (!operation.isDone)
        {
            yield return null;
        }

        if (LoadingPanel != null)
        {
            LoadingPanel.SetActive(false);
        }

    }

    public void GoScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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
        SceneManager.LoadScene("Tutorial");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
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
