using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger2 : MonoBehaviour
{
    public bool event1 = false;

    private void Update()
    {
        if (event1 == true)
        {
            print("event 2 is active");
        }
    }
}
