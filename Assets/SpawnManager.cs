using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject theEnemy;
    public int enemyCount;
    public bool enemySpawned = false;

    private bool safetime = false;
    private bool c = false;
    private bool alltime = false;
    private int chosespawntime;
    private int delay;
    private bool b = false;
    private float angle = 360f;
    private Player player;

    private Flashlight flashlight;
    private XRController controller;
    private XRBaseInteractor interactor;
    private XRGrabInteractable grabInteractable;

    public AudioClip sp1;
    public AudioClip sp2;
    public AudioClip sp3;

    public void OnGrab()
    {
        c = true;
    }

    public void OnRelease()
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
                StartCoroutine(timer(10f));
                Instantiate(theEnemy);
                theEnemy.transform.position = Random.insideUnitCircle * 5;
                enemySpawned = true;
                alltime = true;
                b = true;
            }
        }
        SpawnStart();
        
    }

    private void SpawnStart()
    {
        if (b)
        {
            if (alltime && !enemySpawned)
            {
                delay = Random.Range(30, 121);
                print(delay);
                StartCoroutine(timer(10f));


                int spawners = Random.Range(1, 4);
                print(spawners);

                if (spawners == 1)
                {
                    spawn1();
                }

                if (spawners == 2)
                {
                    spawn2();
                }

                if (spawners == 3)
                {
                    spawn3();
                }
                enemySpawned = true;
                b = false;
            }
        }
        b = true;
    }



    private void spawn1()
    {
        print("spawntime = 1");
        int n;
        n = Random.Range(3, 11);
        print(n);
        GetComponent<AudioSource>().clip = sp1;
        GetComponent<AudioSource>().Play();
        StartCoroutine(timer(3f));
        print("timerpassed");
        Instantiate(theEnemy);
        theEnemy.transform.position = Random.insideUnitCircle * 5;
        
    }
    private void spawn2()
    {
        print("spawntime = 2");
        int n;
        n = Random.Range(30, 46);
        print(n);
        GetComponent<AudioSource>().clip = sp2;
        GetComponent<AudioSource>().Play();
        StartCoroutine(timer(10f));
        print("timerpassed");
        Instantiate(theEnemy);
        theEnemy.transform.position = Random.insideUnitCircle * 5;
    }
    private void spawn3()
    {
        print("spawntime = 3");
        int n;
        n = Random.Range(3, 46);
        print(n);
        GetComponent<AudioSource>().clip = sp3;
        GetComponent<AudioSource>().Play();
        StartCoroutine(timer(7f));
        print("timepassed");
        Instantiate(theEnemy);
        theEnemy.transform.position = Random.insideUnitCircle * 5;
    }

    IEnumerator timer(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
