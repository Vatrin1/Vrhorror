using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerEventManager : MonoBehaviour
{
    public static Action<string> InTrigger;

    string test = "Ай! ";
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Я в триггере");

        InTrigger?.Invoke(test);
    }
}
