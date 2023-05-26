using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public bool button = false;
    public void StartBtn()
    {
        button = true;
    }
    public void ExitBtn()
    {
            Application.Quit();
    }
}
