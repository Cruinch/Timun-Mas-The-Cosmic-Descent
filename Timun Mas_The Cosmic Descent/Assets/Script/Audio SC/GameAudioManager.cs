using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameAudioManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle muteToggle;
    public AudioSource backgroundMusic;

    private bool isMuted = false;

    private void Start()
    {
        // Pastikan volumeSlider dan backgroundMusic telah diinisialisasi sebelum menggunakannya
        if (volumeSlider == null || backgroundMusic == null)
        {
            Debug.LogError("volumeSlider atau backgroundMusic belum diinisialisasi. Periksa referensi Anda.");
            return; // Hentikan eksekusi jika referensi tidak ada
        }

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume");
            volumeSlider.value = savedVolume;
            backgroundMusic.volume = savedVolume;
            isMuted = (savedVolume == 0);
            muteToggle.isOn = isMuted;
        }
        else
        {
            volumeSlider.value = backgroundMusic.volume;
            isMuted = (volumeSlider.value == 0);
            muteToggle.isOn = isMuted;
        }

        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        muteToggle.onValueChanged.AddListener(ToggleMute);

        Invoke("PlayBackgroundMusic", 2f);
    }

    void PlayBackgroundMusic()
    {
        backgroundMusic.Play();
    }

    public void ChangeVolume(float volume)
    {
        backgroundMusic.volume = volume;
        isMuted = (volume == 0);
        muteToggle.isOn = isMuted;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void ToggleMute(bool isMuted)
    {
        this.isMuted = isMuted;
        if (isMuted)
        {
            backgroundMusic.volume = 0;
        }
        else
        {
            backgroundMusic.volume = volumeSlider.value;
        }
        PlayerPrefs.SetFloat("MusicVolume", backgroundMusic.volume);
    }
}
