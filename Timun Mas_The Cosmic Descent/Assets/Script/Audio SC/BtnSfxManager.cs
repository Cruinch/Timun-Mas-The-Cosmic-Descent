using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSfxManager : MonoBehaviour
{
    public AudioSource audiosrc;
    public AudioClip click_btn, hover_btn;

    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
        if (audiosrc == null)
        {
            Debug.LogError("AudioSource component is missing.");
        }
    }

    public void ClickSound()
    {
        audiosrc.clip = click_btn;
        audiosrc.Play();
    }

    public void HoverSound()
    {
        audiosrc.clip = hover_btn;
        audiosrc.Play();
    }
}
