using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider; // Slider untuk mengatur volume
    public Toggle muteToggle;   // Toggle untuk mute/unmute
    public AudioSource backgroundMusic; // Komponen AudioSource musik latar belakang

    private bool isMuted = false; // Status mute/unmute

    private static AudioManager instance;

/*    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Menambahkan listener untuk event sceneLoaded
        }
        else
        {
            // Destroy this instance if another AudioManager already exists
            Destroy(gameObject);
            return;
        }
    }*/

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

        // Mulai pemutaran musik latar belakang
        backgroundMusic.Play();
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

/*    // Callback yang dipanggil saat scene dimuat
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Test Level")
        {
            // Scene "Test Level" dimuat, jadi hentikan musik latar belakang
            backgroundMusic.Stop();
        }
        else if (scene.name == "MainMenu")
        {
            // Kembali ke scene "MainMenu", jadi mulai pemutaran musik latar belakang
            backgroundMusic.Play();
        }
        else if (scene.name == "Level Choice")
        {
            // Kembali ke scene "Level Choice", jadi mulai pemutaran musik latar belakang
            backgroundMusic.Play();
        }
    }

    // Hapus listener saat objek dihancurkan
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }*/
}
