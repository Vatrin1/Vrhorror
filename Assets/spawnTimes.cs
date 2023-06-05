using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTimes : MonoBehaviour
{
    public bool firstSpawnActive;
    public bool constantSpawnActive;
    private bool spawnStopped;
    public bool stop;
    public bool start;
    private float startTime;
    private float remainingTime;
    private float neededTime;
    private int signal;

    public AudioClip sp1;
    public AudioClip sp2;
    public AudioClip sp3;
    void Start()
    {
        startTime = Time.time;
        firstSpawnActive = false;
        constantSpawnActive = false;
        spawnStopped = false;
    }
    void Update()
    {
        if (stop)
        {
            gameObject.SetActive(false);
            StopAllCoroutines();
            spawnStopped = true;
            stop = false;
        }
        if (start)
        {
            if (remainingTime > 0)
            {
                StartCoroutine(timerSpawn(remainingTime));
            }
            else
            {
                gameObject.SetActive(true);
            }
            spawnStopped = false;
            start = false;
        }

        if (!spawnStopped)
        {
            if (firstSpawnActive)
            {
                StartCoroutine(timerSpawn(60));
                startTime = Time.time;
                neededTime = 60;
                firstSpawnActive = false;
            }
            if (constantSpawnActive)
            {
                signal = Random.Range(0, 3);
                switch (signal)
                {
                    case 0:
                        neededTime = Random.Range(5, 11);
                        GetComponent<AudioSource>().clip = sp1;
                        GetComponent<AudioSource>().Play();
                        break;
                    case 1:
                        neededTime = Random.Range(30, 45);
                        GetComponent<AudioSource>().clip = sp2;
                        GetComponent<AudioSource>().Play();
                        break;
                    case 2:
                        GetComponent<AudioSource>().clip = sp3;
                        GetComponent<AudioSource>().Play();
                        neededTime = Random.Range(10, 45);
                        break;
                }
                StartCoroutine(timerSpawn(neededTime));
                startTime = Time.time;
                constantSpawnActive = false;
            }
            remainingTime = neededTime - (Time.time - startTime);
        }
    }
    IEnumerator timerSpawn(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(true);
    }
}