using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour
{
        public Button level1Button; // Tombol untuk menuju Level 1
        public Button level2Button; // Tombol untuk menuju Level 2
        public Button levelBossButton; // Tombol untuk menuju Level 3

    public void Start()
    {
        int levelTutorialCompleted = PlayerPrefs.GetInt("LevelTutorialCompleted", 0);
        int level1Completed = PlayerPrefs.GetInt("Level1Completed", 0);
        int level2Completed = PlayerPrefs.GetInt("Level2Completed", 0);

        Debug.Log("LevelTutorialCompleted: " + levelTutorialCompleted);
        Debug.Log("Level1Completed: " + level1Completed);
        Debug.Log("Level2Completed: " + level2Completed);


        // Periksa apakah Level Tutorial telah selesai
        if (PlayerPrefs.GetInt("LevelTutorialCompleted", 1) == 2)
        {
            // Aktifkan tombol menuju Level 1
            level1Button.interactable = true;
        }
        else
        {
            // Nonaktifkan tombol jika Level Tutorial belum selesai
            level1Button.interactable = false;
        }

        // Periksa apakah Level 1 telah selesai
        if (PlayerPrefs.GetInt("Level1Completed", 1) == 2)
        {
            // Aktifkan tombol menuju Level 2
            level2Button.interactable = true;
        }
        else
        {
            // Nonaktifkan tombol jika Level 1 belum selesai
            level2Button.interactable = false;
        }

        // Periksa apakah Level 2 telah selesai
        if (PlayerPrefs.GetInt("Level2Completed", 1) == 2)
        {
            // Aktifkan tombol menuju Level 3
            levelBossButton.interactable = true;
        }
        else
        {
            // Nonaktifkan tombol jika Level 2 belum selesai
            levelBossButton.interactable = false;
        }
    }

}
