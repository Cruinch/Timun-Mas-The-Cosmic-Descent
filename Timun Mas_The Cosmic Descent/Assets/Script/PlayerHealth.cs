using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Untuk mengelola scene
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Nyawa maksimal pemain
    private int currentHealth; // Nyawa saat ini pemain
    private Animator animator; // Animator pemain
    public float restartDelay = 2f; // Waktu jeda sebelum mengulang permainan
    public Text healthText; // Referensi ke komponen Text yang akan menampilkan nyawa

    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        UpdateHealthText();
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

        // Perbarui teks nyawa setiap kali nyawa berubah
        UpdateHealthText();
    }

    public void Heal()
    {
        currentHealth += 20;
        UpdateHealthText(); 
    }

    private void Die()
    {
        // Memainkan animasi "die" jika komponen Animator tersedia
        if (animator != null)
        {
            animator.SetTrigger("Die"); // Atur parameter "Die" sesuai dengan nama trigger animasi Anda
        }

        // Mengulang permainan/scene setelah waktu jeda (restartDelay)
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        // Tunggu sebelum mengulang permainan/scene
        yield return new WaitForSeconds(restartDelay);

        // Mengulang permainan/scene dengan memuat ulang scene saat ini
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    private void UpdateHealthText()
    {
        // Perbarui teks nyawa dengan nilai nyawa saat ini
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }
}
