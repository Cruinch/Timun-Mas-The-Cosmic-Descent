using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Vector2 checkpointPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Simpan posisi checkpoint ke dalam variabel pemain
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            player.SetCheckpoint(checkpointPosition);
        }
    }
}

