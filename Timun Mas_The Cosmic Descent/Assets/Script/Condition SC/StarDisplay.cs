using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    public Image[] starImagesTestLevel; // Array gambar bintang untuk Test Level
    public Image[] starImagesTutorial; // Array gambar bintang untuk Tutorial
    public Image[] starImagesLevel1; // Array gambar bintang untuk level 1
    public Image[] starImagesLevel2; // Array gambar bintang untuk level 2
    public Image[] starImagesLevel3; // Array gambar bintang untuk level 3

    private void Start()
    {
        // Dapatkan nilai "StarRate" untuk setiap level dari PlayerPrefs
        int starRateTestLevel = PlayerPrefs.GetInt("StarRateTestLevel", 0);
        int starRateTutorial = PlayerPrefs.GetInt("StarRateTutorial", 0);
        int starRateLevel1 = PlayerPrefs.GetInt("StarRateLevel1", 0);
        int starRateLevel2 = PlayerPrefs.GetInt("StarRateLevel2", 0);
        int starRateLevel3 = PlayerPrefs.GetInt("StarRateLevel3", 0);

        // Aktifkan gambar bintang sesuai dengan bintang yang telah diperoleh untuk masing-masing level
        ActivateStars(starImagesTestLevel, starRateTestLevel);
        ActivateStars(starImagesTutorial, starRateTutorial);
        ActivateStars(starImagesLevel1, starRateLevel1);
        ActivateStars(starImagesLevel2, starRateLevel2);
        ActivateStars(starImagesLevel3, starRateLevel3);
    }

    private void ActivateStars(Image[] starImages, int starRate)
    {
        // Pastikan array starImages tidak null dan memiliki elemen
        if (starImages != null && starImages.Length > 0)
        {
            for (int i = 0; i < starImages.Length; i++)
            {
                // Pastikan gambar bintang yang diakses tidak null
                if (starImages[i] != null)
                {
                    starImages[i].gameObject.SetActive(i < starRate);
                }
            }
        }
    }
}
