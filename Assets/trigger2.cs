using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class trigger2 : MonoBehaviour
{
    private bool c = false;
    private XRBaseInteractor interactor;
    private XRController controller;
    private XRGrabInteractable grabInteractable;
    public bool door1 = true;
    public bool door2 = false;
    public AudioClip breakwood;
    public bool event1;

    private void Update()
    {
        if (event1)
        {
            if (c)
            {
                StartCoroutine(timer(2f));
                GetComponent<AudioSource>().clip = breakwood;
                GetComponent<AudioSource>().Play();
            }
        }
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        c = true;
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        c = false;
    }

    IEnumerator timer(float time)
    {
        yield return new WaitForSeconds(time);
    }
}

