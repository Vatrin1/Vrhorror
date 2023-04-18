using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Flashlight : MonoBehaviour
{
    public GameObject light;
    public InputActionProperty pinchAnimatonActionLeft;
    public InputActionProperty pinchAnimatonActionRight;
    public bool isActive = false;
    public bool isButtonPressed = false;
    public bool check = false;
    private bool c = false;
    private XRController controller;
    private XRBaseInteractor interactor;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        light.SetActive(false);
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
        light.SetActive(false);
        isActive = false;
        isButtonPressed = false;
    }



    void Update()
    {
        if (c)
        {
            if ((pinchAnimatonActionLeft.action.ReadValue<float>() == 1 || pinchAnimatonActionRight.action.ReadValue<float>() == 1))
            {
                if (!check)
                {
                    if (!isButtonPressed)
                    {
                        isActive = true;
                    }
                    else
                    {
                        isActive = false;
                    }
                    isButtonPressed = !isButtonPressed;
                }
                check = true;
            }
            else
                check = false;

            if (isActive)
            {
                light.SetActive(true);
            }
            else
            {
                light.SetActive(false);
            }
        }
    }

}
