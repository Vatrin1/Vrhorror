using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerEventManager : MonoBehaviour
{
    public GameObject Enemy;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Event"))
        {
            Invoke(nameof(DestroyEnemy), .1f);
        }
    }
    private void DestroyEnemy()
    {
        Destroy(Enemy);
    }
}
