using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerEventManager : MonoBehaviour
{
    private Ai enemy;
    public bool enemySpawned;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Event"))
        {
            collider.CompareTag("Enemy");
            Destroy(collider.gameObject);
            enemySpawned = false;
            FindObjectOfType<Player>().gameObject.GetComponent<SpawnManager>().enemySpawned = false;
        }
    }
    private void DestroyEnemy()
    {
        Destroy(enemy);
    }
}
