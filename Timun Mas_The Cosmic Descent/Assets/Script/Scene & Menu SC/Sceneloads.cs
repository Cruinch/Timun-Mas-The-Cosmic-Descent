using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sceneloads : MonoBehaviour
{
    public string scenename;
    void Start()
    {
        SceneManager.LoadScene(scenename);
    }
}
