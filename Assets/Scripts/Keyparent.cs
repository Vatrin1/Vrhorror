using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyparent : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _power;

    public AudioClip key;

    private const string ACTION_TAG = "parentkey";
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag(ACTION_TAG))
        {
            return;
        }
        GetComponent<AudioSource>().clip = key;
        GetComponent<AudioSource>().Play();
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(Vector3.up * _power);
        Destroy(collider.gameObject);

    }
}
