using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public InventoryObject hotbarInventory;
    public GameObject sparkle;

    private void Awake()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Drops"))
        {
            var drop = collision.GetComponent<OreDrop>();
            if (drop)
            {
                hotbarInventory.AddDrop(drop.dropObject, 1);
                Instantiate(sparkle, collision.gameObject.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
            }
        }           
    }

    private void OnApplicationQuit()
    {
        hotbarInventory.Container.Clear();
    }
}
