using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject theEnemy;
    public GameObject Eventitem;
    public int enemyCount;
    public bool enemySpawned = false;

    private bool safetime = false;
    private bool c = false;
    private bool alltime = false;

    private Flashlight flashlight;
    private XRController controller;
    private XRBaseInteractor interactor;
    private XRGrabInteractable grabInteractable;

    public AudioClip sp1;
    public AudioClip sp2;
    public AudioClip sp3;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        controller = GetComponent<XRController>();
        flashlight = GetComponent<Flashlight>();
    }
    private void OnGrab(XRBaseInteractor interactor)
    {
        c = true;
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        c = false;
    }

    private void Update()
    {
        if(alltime == false)
        {
            if (c)
            {
                print("c = true");
                if (Eventitem)
                {
                    print("fonarik");
                    StartCoroutine(pretimer(5f));
                    theEnemy.transform.position = Random.insideUnitCircle * 5;
                    enemySpawned = true;
                    alltime = true;
                }
                else
                {
                    print("ne fonarik");
                }
            }
        }
        if (alltime == true && enemySpawned == false)
        {
            print("alltime robit");

            int spawndelay = Random.Range(30, 121);
            print(spawndelay);
            StartCoroutine(spawntimer(spawndelay));

            int chosespawntime = Random.Range(1, 4);
            print(chosespawntime);

            if (chosespawntime == 1)
            {
                print("spawntime = 1");
                int n = Random.Range(3, 11);
                print(n);
                GetComponent<AudioSource>().clip = sp1;
                GetComponent<AudioSource>().Play();
                StartCoroutine(spawntimer(n));
                theEnemy.transform.position = Random.insideUnitCircle * 5;
                enemySpawned = true;
            }
            if (chosespawntime == 2)
            {
                print("spawntime = 2");
                int n = Random.Range(30, 46);
                print(n);
                GetComponent<AudioSource>().clip = sp2;
                GetComponent<AudioSource>().Play();
                StartCoroutine(spawntimer(n));
                theEnemy.transform.position = Random.insideUnitCircle * 5;
                enemySpawned = true;
            }
            if (chosespawntime == 3)
            {
                print("spawntime = 3");
                int n = Random.Range(3, 46);
                print(n);
                GetComponent<AudioSource>().clip = sp3;
                GetComponent<AudioSource>().Play();
                StartCoroutine(spawntimer(n));
                theEnemy.transform.position = Random.insideUnitCircle * 5;
                enemySpawned = true;
            }
        }
    }

    IEnumerator pretimer(float time)
    {
        yield return new WaitForSeconds(time);
    }
    IEnumerator spawntimer(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
