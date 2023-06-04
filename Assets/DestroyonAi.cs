using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyonAi : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _power;

    public AudioClip breakwood;

    private const string ACTION_TAG = "Enemy";

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag(ACTION_TAG))
        {
            return;
        }
        Destroy(_rigidbody.GetComponent<HingeJoint>());
        GetComponent<AudioSource>().clip = breakwood;
        GetComponent<AudioSource>().Play();
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(Vector3.forward * _power);
    }
}
