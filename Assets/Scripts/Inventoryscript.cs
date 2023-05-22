using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class inventory
{
    public GameObject gameObject;
    [Range(0.01f, 1f)]
    public float heightRatio;
}
public class Inventoryscript : MonoBehaviour
{
    public GameObject hmd;
    public inventory[] _inventory;

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
