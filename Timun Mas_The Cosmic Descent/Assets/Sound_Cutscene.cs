using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Cutscene : MonoBehaviour
{
    public AudioSource audiosrc;
    public AudioClip Boss_Cutscene,Prolog_Cutscene1, Prolog_Cutscene2, Prolog_Cutscene3, Prolog_Cutscene4;

    public void BossSound()
    {
        audiosrc.clip = Boss_Cutscene;
        audiosrc.Play();
    }

    public void PrologSound1()
    {
        audiosrc.clip = Prolog_Cutscene1;
        audiosrc.Play();
    }
    public void PrologSound2()
    {
        audiosrc.clip = Prolog_Cutscene2;
        audiosrc.Play();
    }

    public void PrologSound3()
    {
        audiosrc.clip = Prolog_Cutscene3;
        audiosrc.Play();
    }

    public void PrologSound4()
    {
        audiosrc.clip = Prolog_Cutscene4;
        audiosrc.Play();
    }
}
