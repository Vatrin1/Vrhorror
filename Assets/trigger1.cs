using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger1 : MonoBehaviour
{
    public bool event1 = false;
    public AudioClip fireon;
    public AudioClip fireoff;
    GameObject fire;

    private void Awake()
    {
        OnFireing();
    }

    public void OnTriggerExit(Collider other)
    {
        Destroy(fire.gameObject);
        OffFireing();
        GetComponent<AudioSource>().clip = fireoff;
        GetComponent<AudioSource>().Play();
        event1 = true;
        FindObjectOfType<trigger1>().gameObject.GetComponent<trigger2>().event1 = true;
        OffFireing();
    }

    private void OnFireing()
    {
        GetComponent<AudioSource>().clip = fireon;
        GetComponent<AudioSource>().Play();
    }

    private void OffFireing()
    {
        GetComponent<AudioSource>().clip = fireon;
        GetComponent<AudioSource>().Stop();
    }

}
