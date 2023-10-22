using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animator animator;
    private Collider2D enemyCollider;
    private Rigidbody2D rb;
    private bool isDead = false;
    private EnemyAI enemyAI;
    public Text healthText;

    public GameObject wintxt; // Objek teks "Gameovertxt" dalam hierarki Unity

    public WinPanelManager winPanelManager; // Referensi ke WinPanelManager


    private void Start()
    {
        wintxt.SetActive(false);
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        enemyCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        enemyAI = GetComponent<EnemyAI>();

        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= damage;

        if (animator != null)
        {
            animator.SetTrigger("Hurt");
        }

        // Pastikan bahwa nyawa tidak kurang dari 0
        currentHealth = Mathf.Max(currentHealth, 0);

        if (currentHealth <= 0)
        {
            Die();
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(50);
            }
            if (winPanelManager != null)
            {
                winPanelManager.ShowWinPanel(); // Memanggil fungsi ShowWinPanel pada WinPanelManager
            }

        }

        UpdateHealthText();
    }

    private void Die()
    {
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        if (enemyCollider != null)
        {
            enemyCollider.enabled = false;
        }

        if (enemyAI != null)
        {
            enemyAI.enabled = false;
        }

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }

        isDead = true;
        wintxt.SetActive(true);

        ScoreManager scoreManager = ScoreManager.instance;
        if (scoreManager != null)
        {
            scoreManager.AddScore(1000); // Menambahkan 1000 poin
        }
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }
}