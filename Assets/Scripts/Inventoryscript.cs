using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[System.Serializable]

public class inventory
{
    public GameObject gameObject;
    [Range(0.01f, 1f)]
    public float heightRatio;
}
public class Inventoryscript : MonoBehaviour
{
    public Transform Lefttarget;
    public Transform Righttarget;
    public GameObject hmd;
    public inventory[] _inventory;
    public float showInventoryDistance = 0.05f;
    public Renderer nonInventory;

    private Vector3 hmdPosition;
    private Quaternion hmdRotation;

    private void Update()
    {
        hmdPosition = hmd.transform.position;
        hmdRotation = hmd.transform.rotation;
        foreach(var inventory in _inventory)
        {
            UpdateInventoryHeight(inventory);
        }
        UpdateInventory();

        float leftdistance = Vector3.Distance(transform.position, Lefttarget.position);

        if (leftdistance < showInventoryDistance)
        {
            nonInventory.enabled = true;
        }
        else
        {
            nonInventory.enabled = false;
        }

        float rightdistance = Vector3.Distance(transform.position, Righttarget.position);

        if (rightdistance < showInventoryDistance)
        {
            nonInventory.enabled = true;
        }
        else
        {
            nonInventory.enabled = false;
        }
    }

    private void UpdateInventoryHeight (inventory inventory)
    {
        inventory.gameObject.transform.position = new Vector3(inventory.gameObject.transform.position.x, hmdPosition.y * inventory.heightRatio, inventory.gameObject.transform.position.z);
    }

    private void UpdateInventory()
    {
        transform.position = new Vector3(hmdPosition.x, 0, hmdPosition.z);
        transform.rotation = new Quaternion(transform.rotation.x, hmdRotation.y, transform.rotation.z ,hmdRotation.w);
    }
}
