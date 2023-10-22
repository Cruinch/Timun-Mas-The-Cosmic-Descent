using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f; // Kecepatan pergerakan karakter musuh
    public float chaseRadius = 5f; // Jarak pemain yang akan dikejar

    public Transform attackPoint; // Titik serangan karakter
    public float attackRadius = 1f; // Radius serangan karakter
    public LayerMask playerLayer; // Layer karakter pemain
    public int attackDamage = 50; // Damage serangan karakter
    public float attackCooldown = 2f; // Jeda antara serangan
    public float attackDelay = 1f; // Jeda sebelum menyerang

    private Transform player; // Referensi ke karakter pemain
    private Animator animator;
    private Collider2D enemyCollider;
    private bool isAttacking = false; // Apakah karakter musuh sedang menyerang

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyCollider = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform; // Cari karakter pemain
        StartCoroutine(AttackDelay());
    }

    private void Update()
    {
        // Mengukur jarak antara karakter musuh dan pemain
        float distanceToPlayer = Mathf.Abs(player.position.x - transform.position.x);

        // Cek apakah pemain berada dalam jangkauan serangan
        if (distanceToPlayer <= attackRadius && !isAttacking)
        {
            Attack();
        }
        // Cek apakah pemain berada dalam jarak pemindahan (chaseRadius)
        else if (distanceToPlayer <= chaseRadius)
        {
            // Mengarahkan karakter musuh ke arah pemain secara horizontal
            float moveDirection = Mathf.Sign(player.position.x - transform.position.x);
            transform.Translate(new Vector3(moveDirection * moveSpeed * Time.deltaTime, 0f, 0f));

            // Mengatur animator parameter "Speed" sesuai dengan kecepatan pergerakan
            animator.SetFloat("Speed", Mathf.Abs(moveDirection * moveSpeed));

            // Mengatur arah hadapan karakter musuh berdasarkan arah horizontal
            if (moveDirection > 0)
            {
                // Menghadap kanan
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (moveDirection < 0)
            {
                // Menghadap kiri
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
        // Jika pemain di luar jangkauan serangan dan pemindahan, menghentikan animasi run
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }

    private void Attack()
    {
        // Mengaktifkan animasi serangan
        isAttacking = true;

        // Memainkan animasi "Attack" jika komponen Animator tersedia
        if (animator != null)
        {
            animator.SetTrigger("Attack"); // Atur parameter "Attack" sesuai dengan nama trigger animasi Anda
        }

        // Cek apakah karakter pemain berada dalam jangkauan serangan
        Collider2D playerCollider = Physics2D.OverlapCircle(attackPoint.position, attackRadius, playerLayer);
        if (playerCollider != null)
        {
            // Dapatkan komponen karakter pemain dengan aman
            PlayerHealth playerHealth = playerCollider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Kurangi health karakter pemain sesuai dengan attackDamage
                playerHealth.TakeDamage(attackDamage);
            }
        }

        // Menunggu sebelum karakter musuh dapat menyerang lagi
        StartCoroutine(AttackCooldown());
    }


    private IEnumerator AttackCooldown()
    {
        // Menunggu sebelum karakter musuh dapat menyerang lagi
        yield return new WaitForSeconds(attackCooldown);

        // Setelah jeda, karakter musuh dapat menyerang lagi
        isAttacking = false;
    }

    private IEnumerator AttackDelay()
    {
        // Menunggu sebelum karakter musuh mulai menyerang
        yield return new WaitForSeconds(attackDelay);

        // Setelah jeda, karakter musuh dapat mulai menyerang
        Attack();
    }
}
