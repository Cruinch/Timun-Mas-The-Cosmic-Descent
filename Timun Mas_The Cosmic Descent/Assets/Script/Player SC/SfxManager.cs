using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public AudioSource audiosrc;
    public AudioClip runS, jumpS, attackS, hurtS, dieS, gameOverS, itemS, healS, cpointS, winS;

    public void RunSound()
    {
        audiosrc.clip = runS;
        audiosrc.Play();
    }
    public void JumpSound()
    {
        audiosrc.clip = jumpS;
        audiosrc.Play();
    }
    public void AttackSound()
    {
        audiosrc.clip = attackS;
        audiosrc.Play();
    }
    public void HurtSound()
    {
        audiosrc.clip = hurtS;
        audiosrc.Play();
    }
    public void DieSound()
    {
        audiosrc.clip = dieS;
        audiosrc.Play();
    }

    public void GoverSound()
    {
        audiosrc.clip = gameOverS;
        audiosrc.Play();
    }

    public void ItemSound()
    {
        audiosrc.clip = itemS;
        audiosrc.Play();
    }

    public void HealSound()
    {
        audiosrc.clip = healS;
        audiosrc.Play();
    }

    public void CPointSound()
    {
        audiosrc.clip = cpointS;
        audiosrc.Play();
    }

    public void WinSound()
    {
        audiosrc.clip = winS;
        audiosrc.Play();
    }

}
