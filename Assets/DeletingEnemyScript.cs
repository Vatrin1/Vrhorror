using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletingEnemyScript : MonoBehaviour
{
    private GameObject _gameObject;
    private const string ENEMY_TAG = "Enemy";

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag(ENEMY_TAG))
        {
            return;
        }

        Destroy(_gameObject);
    }
}
