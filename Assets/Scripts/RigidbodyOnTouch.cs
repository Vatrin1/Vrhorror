using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RigidbodyOnTouch : MonoBehaviour
{
    public bool TouchedObject;
    private XRGrabInteractable grabInteractable;
    void Start()
    {
        TouchedObject = false;
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    //private void OnEnable()
    //{
        //grabInteractable.onSelectEntered.AddListener(OnGrab);
        //grabInteractable.onSelectExited.AddListener(OnRelease);
    //}

    //private void OnDisable()
    //{
        //grabInteractable.onSelectEntered.RemoveListener(OnGrab);
        //grabInteractable.onSelectExited.RemoveListener(OnRelease);
    //}

    void OnCollisionEnter(Collision collision)
    {
        if (!TryGetComponent<TouchedItem>(out TouchedItem touchedItem))
        {
            if (collision.gameObject.name == "Left Hand Presence Physics" || collision.gameObject.name == "Right Hand Presence Physics" || collision.gameObject.TryGetComponent<TouchedItem>(out TouchedItem touched))
            {
                print(gameObject.GetComponent<Rigidbody>().isKinematic);
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.AddComponent<TouchedItem>();
                print(gameObject.GetComponent<Rigidbody>().isKinematic);
            }
            else
            {

            }
        }
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        print("huinia");
        if (!TryGetComponent<TouchedItem>(out TouchedItem touchedItem))
        {
            print(gameObject.GetComponent<Rigidbody>().isKinematic);
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.AddComponent<TouchedItem>();
            print(gameObject.GetComponent<Rigidbody>().isKinematic);
        }
    }
}
