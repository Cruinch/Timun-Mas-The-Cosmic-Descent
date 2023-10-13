using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Sprites;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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

