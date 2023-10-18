using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject[] enemies; // Array untuk menyimpan game object musuh
    public GameObject youWinText; // Game object "You Win" yang akan muncul

    private int defeatedEnemies = 0; // Menghitung jumlah musuh yang sudah mati

    private void Start()
    {
        youWinText.SetActive(false); // Sembunyikan "You Win" saat game dimulai
    }

    // Fungsi untuk memanggil ketika musuh mati
    public void EnemyDied()
    {
        defeatedEnemies++; // Tambahkan jumlah musuh yang sudah mati

        if (defeatedEnemies == 1) // Jika sudah ada 3 musuh yang mati
        {
            youWinText.SetActive(true); // Tampilkan "You Win"
        }
    }
}

