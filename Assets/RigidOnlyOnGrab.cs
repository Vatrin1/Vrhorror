using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RigidOnlyOnGrab : MonoBehaviour
{
    public bool check = false;
    private bool c = false;
    private XRController controller;
    private XRBaseInteractor interactor;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        controller = GetComponent<XRController>();
        grabInteractable = GetComponent<XRGrabInteractableToAttach>();
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
        grabInteractable = GetComponent<XRGrabInteractable>();
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
