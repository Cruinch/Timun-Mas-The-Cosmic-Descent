using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Nyawa maksimal pemain
    private int currentHealth; // Nyawa saat ini pemain
    public int lives = 3;
    public int currentLives;
    private Animator animator; // Animator pemain
    public float restartDelay = 2f; // Waktu jeda sebelum mengulang permainan
    
    public Text healthText; // Referensi ke komponen Text yang akan menampilkan nyawa
    public Slider healthSlider; // Referensi ke komponen Slider untuk menampilkan nyawa
    public Text livesText;

    private Vector2 checkpoint;
    public GameObject gameOverText; // Objek teks "Gameovertxt" dalam hierarki Unity

    private PlayerControl playerControlScript; // Referensi ke komponen "PlayerControl"

    private Rigidbody2D playerRb;

    SfxManager sfxManager;
    BackgroundMusicController backgroundMusicController;

    //private static PlayerHealth instance;

    private void Start()
    {
        gameOverText.SetActive(false);

        currentLives = lives;
        currentHealth = maxHealth;

        animator = GetComponent<Animator>();
        UpdateHealthSlider();
        UpdateHealthText();
        
        sfxManager = GetComponent<SfxManager>();
        backgroundMusicController = GetComponent<BackgroundMusicController>();
    }

    public void TakeDamage(int damage)
    {
        // Kurangi nyawa pemain sesuai dengan damage yang diterima
        currentHealth -= damage;

        // Memainkan animasi "hurt" jika komponen Animator tersedia
        if (animator != null)
        {
            animator.SetTrigger("Hurt"); // Atur parameter "Hurt" sesuai dengan nama trigger animasi Anda
        }

        // Pastikan bahwa nyawa tidak kurang dari 0
        currentHealth = Mathf.Max(currentHealth, 0);

        // Check jika nyawa pemain habis
        if (currentHealth <= 0)
        {
            Die();
        }

        if (currentLives <= 0)
        {
            GameOver();
            
        }

        // Perbarui teks nyawa setiap kali nyawa berubah
        UpdateHealthText();
        UpdateHealthSlider();
    }

    public void Heal()
    {
        currentHealth += 20;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        UpdateHealthText();
        UpdateHealthSlider();
    }

    public void Die()
    {
        currentLives -= 1;
        animator.SetTrigger("Die");
        UpdateLivesText();
        UpdateHealthSlider();
        playerControlScript = GetComponent<PlayerControl>();
        //playerControlScript.speed = 0;
        if (currentLives <= 0)
        {
            animator.SetTrigger("Die");
            GameOver();
        }
        else
        {
            Respawn();
        }
    }

    public void GameOver()
    {
        // Dapatkan referensi ke komponen "PlayerControl" pada GameObject yang sama
        playerControlScript = GetComponent<PlayerControl>();
        playerControlScript.enabled = false;
        //playerRb = GetComponent<Rigidbody2D>();
        playerControlScript.speed = 0;
        gameOverText.SetActive(true);
        sfxManager.GoverSound();
    }

    public void Restart()
    {
        // Mengulang permainan/scene
        playerControlScript = GetComponent<PlayerControl>();
        playerControlScript.enabled = true;
        RestartGame();

    }

    public void RestartGame()
    {
        // Mengulang permainan/scene dengan memuat ulang scene saat ini
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    private void UpdateHealthSlider()
    {
        // Perbarui nilai Slider dengan nilai nyawa saat ini
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
        }
    }


    private void UpdateHealthText()
    {
        // Perbarui teks nyawa dengan nilai nyawa saat ini
        if (healthText != null)
        {
            //healthText.text = "Health: " +  currentHealth.ToString();
            healthText.text = currentHealth.ToString();
        }
    }

    private void UpdateLivesText()
    {
        // Perbarui teks nyawa dengan nilai nyawa saat ini
        if (livesText != null)
        {
            livesText.text = "X " + currentLives.ToString();
        }
    }

    // Method untuk menetapkan checkpoint pemain
    public void SetCheckpoint(Vector2 position)
    {
        checkpoint = position;
    }

    // Method untuk respawn pemain ke checkpoint
    public void Respawn()
    {
        animator.SetTrigger("NewLife");
        transform.position = checkpoint;
        // Atur ulang nyawa atau status pemain lainnya yang perlu diatur ulang
        currentHealth = 100;
        // Check if other objects that need resetting are not null
        if (playerControlScript != null)
        {
            playerControlScript.speed = 5;
        }
        UpdateHealthText();
        UpdateHealthSlider();
    }
}
