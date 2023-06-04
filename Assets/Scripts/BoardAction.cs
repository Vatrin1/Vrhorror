using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardAction : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _power;

    public AudioClip breakwood;

    private const string ACTION_TAG = "Actionable";
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag(ACTION_TAG))
        {
            return;
        }
        GetComponent<AudioSource>().clip = breakwood;
        GetComponent<AudioSource>().Play();
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(Vector3.up * _power);
    }
}
