using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Ini digunakan untuk mengakses komponen UI Text

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Referensi ke komponen UI Text untuk menampilkan skor
    private int score = 0; // Nilai awal skor

    private void Start()
    {
        UpdateScoreText(); // Memperbarui teks skor pada awal permainan
    }

    // Fungsi untuk menambah skor
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Fungsi untuk memperbarui teks skor
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
