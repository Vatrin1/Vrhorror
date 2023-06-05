using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class Phonescript : MonoBehaviour
{
    private bool playingring = false;
    private bool playingcall = false;

    public AudioClip ringing;
    public AudioClip call;
    public bool button;

    public void ButtonEnable()
    {
        button = true;
        StartCoroutine(pretimer(2f));
    }

    public void GrabPhone()
    {
        if (button == true)
        {
            if (playingring == true)
            {
                GetComponent<AudioSource>().clip = ringing;
                GetComponent<AudioSource>().Stop();
                playingring = false;
            }
            StartCoroutine(aftertimer(20f));
            if (playingcall == false)
            {
                GetComponent<AudioSource>().clip = call;
                GetComponent<AudioSource>().Play();
                playingcall = true;
            }
        }
    }
    IEnumerator pretimer(float time)
    {
        yield return new WaitForSeconds(time);
        GetComponent<AudioSource>().clip = ringing;
        GetComponent<AudioSource>().Play();
        playingring = true;
    }
    IEnumerator aftertimer(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("MainLocation");
    }
}
