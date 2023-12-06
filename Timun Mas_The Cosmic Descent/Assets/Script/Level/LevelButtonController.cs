using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour
{
    public Button level1Button; // Tombol untuk menuju Level 1
    public Button level2Button; // Tombol untuk menuju Level 2
    public Button levelBossButton; // Tombol untuk menuju Level 3

    private void Start()
    {
        // Periksa apakah Level Tutorial telah selesai
        if (PlayerPrefs.GetInt("LevelTutorialCompleted", 0) == 1)
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
        if (PlayerPrefs.GetInt("Level1Completed", 0) == 1)
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
        if (PlayerPrefs.GetInt("Level2Completed", 0) == 1)
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
