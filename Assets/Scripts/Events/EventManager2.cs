using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class EventManager2 : MonoBehaviour
{
    private EventManager1 event1act;

    //if (event1act == true)
    //    {

    //    }

    //private void Start()
    //{
    //    event1act = GetComponent<EventManager1>();
    //}
    private void OnEnable()
    {
        PlayerEventManager.InTrigger += ConsoleMessage;
    }

    private void OnDisable()
    {
        PlayerEventManager.InTrigger -= ConsoleMessage;
    }

    private void ConsoleMessage(string value)
    {
        Debug.Log($"{value}Игрок зашёл в триггер 2");
    }
}
