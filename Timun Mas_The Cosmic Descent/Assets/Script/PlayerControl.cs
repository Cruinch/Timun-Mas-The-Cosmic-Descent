using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f; // Kecepatan karakter
    public float jumpForce = 7f; // Besar gaya lompatan

    public float attackRadius = 1f; // Radius serangan karakter
    public Transform attackPoint; // Titik serangan karakter
    public LayerMask enemyLayer; // Layer musuh
    public int attackDamage = 50; // Damage serangan karakter

    private bool isJumping = false; // Apakah karakter sedang melompat
    private bool isAttacking = false; // Apakah karakter sedang menyerang

    private Rigidbody2D rb;
    private Animator animator;
    private bool isFacingRight = true; // Apakah karakter menghadap kanan


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Mengatur animasi berdasarkan kecepatan karakter
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animator.SetBool("IsJump", isJumping);
        animator.SetBool("IsAttack", isAttacking); // Mengatur parameter "IsAttack" dalam animator

        // Mengatur arah karakter
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }

        // Melompat jika tombol Space ditekan
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            Jump();
        }

        // Menyerang jika tombol kiri mouse ditekan
        if (Input.GetKeyDown(KeyCode.K) && !isAttacking)
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        // Menggerakkan karakter ke kiri atau kanan
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = movement;
    }

    private void Jump()
    {
        // Menerapkan gaya lompatan ke karakter
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isJumping = true;
    }

    private void Attack()
    {
        // Mengaktifkan animasi serangan
        isAttacking = true;

        // Mendeteksi objek-objek dalam radius serangan
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);

        // Menjalankan serangan pada objek-objek yang terkena
        foreach (Collider2D enemy in hitEnemies)
        {
            // Pastikan objek yang terkena memiliki komponen yang memungkinkan karakter musuh untuk menerima damage
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {   
                // Kurangi health musuh sesuai dengan attackDamage
                enemyHealth.TakeDamage(attackDamage);
            }
        }

        // Mengatur agar karakter dapat menyerang lagi setelah animasi selesai
        StartCoroutine(ResetAttack());
    }

    private IEnumerator ResetAttack()
    {
        // Tunggu sampai animasi selesai (disesuaikan dengan durasi animasi Anda)
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);

        // Setelah animasi selesai, karakter dapat menyerang lagi
        isAttacking = false;
    }

    private void Flip()
    {
        // Memutar karakter dengan mengubah arah hadapnya
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnDrawGizmosSelected()
    {
        // Menggambar gizmo lingkaran untuk menunjukkan jangkauan serangan
        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Mengatur karakter tidak sedang melompat ketika menyentuh tanah
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        if (collision.gameObject.CompareTag("Trap"))
        {
            PlayerHealth playerHealth = GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(150); // Mengurangi 1 nyawa
            }
        }

        if (collision.gameObject.CompareTag("Heal"))
        {
            PlayerHealth playerHealth = GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal();
                Destroy(collision.gameObject);
            }
        }

        // Memeriksa jika karakter pemain menyentuh objek dengan tag "Item"
        if (collision.gameObject.CompareTag("Item"))
        {
            // Mengambil komponen ScoreManager
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

            // Menambahkan 10 poin ke skor
            if (scoreManager != null)
            {
                scoreManager.AddScore(10);
            }

            // Menghilangkan objek item (opsional)
            Destroy(collision.gameObject);
        }
    }

}