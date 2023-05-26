using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager1 : MonoBehaviour
{
    public bool event1act = false;
    private void OnEnable()
    {
        PlayerEventManager.InTrigger += ConsoleMessage;
        bool event1act = true;
    }

    private void OnDisable()
    {
        PlayerEventManager.InTrigger -= ConsoleMessage;
    }

    private void ConsoleMessage(string value)
    {
        Debug.Log($"{value}Игрок зашёл в триггер 1");
    }
}
