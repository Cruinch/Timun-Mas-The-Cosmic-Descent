using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Import namespace untuk mengelola scene

public class GameAudioManager : MonoBehaviour
{
    public Slider volumeSlider; // Slider untuk mengatur volume
    public Toggle muteToggle;   // Toggle untuk mute/unmute
    public AudioSource backgroundMusic; // Komponen AudioSource musik latar belakang

    private bool isMuted = false; // Status mute/unmute

    private static GameAudioManager instance; // Ubah AudioManager menjadi GameAudioManager

    private void Start()
    {
        // Inisialisasi nilai slider dengan volume awal dari musik
        volumeSlider.value = backgroundMusic.volume;

        // Inisialisasi status mute/unmute berdasarkan volume awal
        isMuted = (volumeSlider.value == 0);
        muteToggle.isOn = isMuted;

        // Tambahkan listener untuk slider
        volumeSlider.onValueChanged.AddListener(ChangeVolume);

        // Tambahkan listener untuk toggle
        muteToggle.onValueChanged.AddListener(ToggleMute);
    }

    // Fungsi untuk mengubah volume musik
    public void ChangeVolume(float volume)
    {
        backgroundMusic.volume = volume;
        isMuted = (volume == 0);
        muteToggle.isOn = isMuted;
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
    }
}
