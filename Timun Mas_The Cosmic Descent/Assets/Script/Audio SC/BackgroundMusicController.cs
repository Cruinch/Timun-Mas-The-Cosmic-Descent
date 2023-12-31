using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusicController : MonoBehaviour
{
    public Slider volumeSlider; // Slider untuk mengatur volume
    public Toggle muteToggle;   // Toggle untuk mute/unmute
    public AudioSource backgroundMusic; // Komponen AudioSource musik latar belakang

    public bool isMuted = false; // Status mute/unmute

    //private static BackgroundMusicController instance;

    private void Start()
    {
        if (volumeSlider != null)
        {
            // Tambahkan listener untuk slider
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }

        // Periksa apakah muteToggle ada dan tidak null
        if (muteToggle != null)
        {
            // Tambahkan listener untuk toggle
            muteToggle.onValueChanged.AddListener(ToggleMute);
        }

        // Cek apakah ada nilai volume tersimpan di PlayerPrefs
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            // Jika ada, atur nilai slider dan volume audio sesuai dengan yang tersimpan
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume");
            volumeSlider.value = savedVolume;
            backgroundMusic.volume = savedVolume;
            isMuted = (savedVolume == 0);
            muteToggle.isOn = isMuted;
        }
        else
        {
            // Jika tidak ada nilai tersimpan, inisialisasi dengan nilai default
            volumeSlider.value = backgroundMusic.volume;
            isMuted = (volumeSlider.value == 0);
            muteToggle.isOn = isMuted;
        }

        backgroundMusic.Play();
    }

    // Fungsi untuk mengubah volume musik
    public void ChangeVolume(float volume)
    {
        backgroundMusic.volume = volume;
        isMuted = (volume == 0);
        muteToggle.isOn = isMuted;

        // Simpan nilai volume ke PlayerPrefs
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    // Fungsi untuk mute/unmute musik
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

        // Simpan nilai volume ke PlayerPrefs saat mute/unmute
        PlayerPrefs.SetFloat("MusicVolume", backgroundMusic.volume);
    }
}