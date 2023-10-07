using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class SceneLoader : MonoBehaviour
{
    public void Level_Choice()
    {
        SceneManager.LoadScene("Level Choice");
    }
}