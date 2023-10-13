using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundManager : MonoBehaviour
{
    public AudioSource enemyaudiosrc;
    public AudioClip runES, attackES, hurtES, dieES;

    public void RunEnemySound()
    {
        enemyaudiosrc.clip = runES;
        enemyaudiosrc.Play();
    }
    public void AttackEnemySound()
    {
        enemyaudiosrc.clip = attackES;
        enemyaudiosrc.Play();
    }
    public void HurtEnemySound()
    {
        enemyaudiosrc.clip = hurtES;
        enemyaudiosrc.Play();
    }
    public void DieEnemySound()
    {
        enemyaudiosrc.clip = dieES;
        enemyaudiosrc.Play();
    }
}
