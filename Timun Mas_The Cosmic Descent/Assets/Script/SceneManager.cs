using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*using static Cinemachine.DocumentationSortingAttribute;*/

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject option; // Referensi ke komponen Renderer
    [SerializeField]
    private GameObject credits; // Referensi ke komponen Renderer
    [SerializeField]
    private GameObject exit; // Referensi ke komponen Renderer

    private bool isVisible = true; // Untuk melacak apakah objek sedang terlihat

    public void Start()
    {
/*        option.SetActive(false);
        credits.SetActive(false);
        exit.SetActive(false);*/
    }
    public void Level_Choice()
    {
        SceneManager.LoadScene("Level Choice");
    }

    public void OptionV()
    {
        isVisible = !isVisible; // Mengubah status terlihat
        option.SetActive(isVisible); // Mengatur status objek berdasarkan status isVisible
    }

    public void CreditsV()
    {
        isVisible = !isVisible; // Mengubah status terlihat
        credits.SetActive(isVisible); // Mengatur status objek berdasarkan status isVisible
    }

    public void ExitV()
    {
        isVisible = !isVisible; // Mengubah status terlihat
        exit.SetActive(isVisible); // Mengatur status objek berdasarkan status isVisible
    }
}