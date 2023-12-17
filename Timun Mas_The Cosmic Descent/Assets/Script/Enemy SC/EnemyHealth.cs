using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animator animator;
    private Collider2D enemyCollider;
    private Rigidbody2D rb;
    private bool isDead = false;
    private EnemyAI enemyAI;

    public Slider healthSlider; // Referensi ke komponen Slider untuk menampilkan nyawa
    public Text healthText;

    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        enemyCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        enemyAI = GetComponent<EnemyAI>();

        UpdateHealthSlider();
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
        }

        UpdateHealthSlider();
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
        animator.SetTrigger("Hide");
        Destroy(gameObject);
        ScoreManager scoreManager = ScoreManager.instance;
        if (scoreManager != null)
        {
            scoreManager.AddScore(100); // Menambahkan 100 poin
        }
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            //healthText.text = "Health: " + currentHealth.ToString();
            healthText.text = currentHealth.ToString();
        }
    }

    private void UpdateHealthSlider()
    {
        // Perbarui nilai Slider dengan nilai nyawa saat ini
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
        }
    }
}
