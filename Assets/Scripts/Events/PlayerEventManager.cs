using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerEventManager : MonoBehaviour
{
    public static Action<string> InTrigger;

    string test = "��! ";
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("� � ��������");

        InTrigger?.Invoke(test);
    }
}
