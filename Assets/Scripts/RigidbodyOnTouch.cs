using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RigidbodyOnTouch : MonoBehaviour
{
    public bool TouchedObject;
    public bool check = false;
    private bool c = false;
    private XRController controller;
    private XRBaseInteractor interactor;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        controller = GetComponent<XRController>();
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        grabInteractable.onSelectEntered.RemoveListener(OnGrab);
        grabInteractable.onSelectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        c = true;
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        c = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }


    void Start()
    {
        TouchedObject = false;
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!TryGetComponent<TouchedItem>(out TouchedItem touchedItem))
        {
            if (collision.gameObject.name == "Left Hand Presence Physics" || collision.gameObject.name == "Right Hand Presence Physics" || collision.gameObject.TryGetComponent<TouchedItem>(out TouchedItem touched))
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.AddComponent<TouchedItem>();
            }
            else
            {

            }
        }
    }

    void Update()
    {
        if (c)
        {
            if (!check)
            {
                check = true;
            }
            else
            {
                check = false;
            }
        }
    }
}
