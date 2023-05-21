using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TposeBehavior : StateMachineBehaviour
{
    private bool c = false;
    private GameObject target;
    private XRController controller;
    private XRBaseInteractor interactor;
    private XRGrabInteractable grabInteractable;
    private GameObject StartItem;
    private void Awake()
    {

        //grabInteractable = GetCompanent<XRGrabInteractable>();
        StartItem = GameObject.FindGameObjectWithTag("SpecialItem");
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
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (c == false && !StartItem.CompareTag("SpectialItem"))
        {
            animator.SetBool("IsWalking", false);
        }
    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (c == true && StartItem.CompareTag("SpectialItem"))
        {
            animator.SetBool("IsWalking", true);
        }
    }


    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
