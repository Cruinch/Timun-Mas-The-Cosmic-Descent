using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPanelController : MonoBehaviour
{
    public GameObject loadingPanel;
    public float loadingDuration = 2.0f;

    private void Start()
    {
        // Aktifkan loading panel saat scene baru dibuka
        if (loadingPanel != null)
        {
            loadingPanel.SetActive(true);
        }

        // Mulai coroutine untuk menonaktifkan loading panel setelah jangka waktu tertentu
        StartCoroutine(DisableLoadingPanel());
    }

    private IEnumerator DisableLoadingPanel()
    {
        // Tunggu selama loadingDuration (dalam detik)
        yield return new WaitForSeconds(loadingDuration);

        // Nonaktifkan loading panel setelah jangka waktu selesai
        if (loadingPanel != null)
        {
            loadingPanel.SetActive(false);
        }
    }
}

