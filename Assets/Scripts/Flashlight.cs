using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Flashlight : MonoBehaviour
{
    public GameObject light;
    public GameObject vlight;
    public GameObject battery;
    public InputActionProperty pinchAnimatonActionLeft;
    public InputActionProperty pinchAnimatonActionRight;
    public bool isActive = false;
    public bool isButtonPressed = false;
    public bool check = false;
    public bool enemySpawned;
    private bool c = false;
    public int charge = 0;
    public int maxCharge = 0;
    private bool chargeCheck = false;
    private XRController controller;
    private XRBaseInteractor interactor;
    private Transform BatteryScale;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        charge = maxCharge;
        light.SetActive(false);
        vlight.SetActive(false);
        controller = GetComponent<XRController>();
        grabInteractable = GetComponent<XRGrabInteractable>();   
    }

    private void OnEnable()
    {
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        grabInteractable.onSelectEntered.RemoveListener(OnGrab);
        grabInteractable.onSelectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        c = true;
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        c = false;
        light.SetActive(false);
        vlight.SetActive(false);
        isActive = false;
        isButtonPressed = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (isActive == true)
        {
            if (collider.CompareTag("Enemy"))
            {
                Destroy(collider.gameObject);
                enemySpawned = false;
                FindObjectOfType<Player>().gameObject.GetComponent<SpawnManager>().enemySpawned = false;
            }
        }
    }
    void Update()
    {
        if (c)
        {
            if ((pinchAnimatonActionLeft.action.ReadValue<float>() == 1 || pinchAnimatonActionRight.action.ReadValue<float>() == 1))
            {
                if (!check)
                {
                    if (!isButtonPressed)
                    {
                        isActive = true;
                    }
                    else
                    {
                        isActive = false;
                    }
                    isButtonPressed = !isButtonPressed;
                }
                check = true;
            }
            else
                check = false;

            if (isActive)
            {
                light.SetActive(true);
                vlight.SetActive(true);
            }
            else
            {
                light.SetActive(false);
                vlight.SetActive(false);
            }
        }
        if (isActive)
        {
            if (charge == 0)
                isActive = false;
            if (!chargeCheck)
            {
                StartCoroutine(chargeDown(1f));
                chargeCheck = true;
            }
        }
        else
        {
            if (charge != 0)
            {
                if (!chargeCheck)
                {
                    StartCoroutine(chargeUp(2f));
                    chargeCheck = true;
                }
            }
        }
    }

    void FixedUpdate()
    {
        //battery.transform.localScale = new Transform(BatteryScale.x, charge * 0.01 , BatteryScale.z);
    }

    IEnumerator chargeDown(float time)
    {
        yield return new WaitForSeconds(time);
        if (charge>0)
            charge--;
        chargeCheck = false;
        
    }

    IEnumerator chargeUp(float time)
    {
        yield return new WaitForSeconds(time);
        if (charge < maxCharge)
            charge++;
        chargeCheck = false;
    }


}
