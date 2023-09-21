using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semente : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerinventory = other.GetComponent<PlayerInventory>();
        if (playerinventory != null)
        {
            playerinventory.SeedCollected();
            gameObject.SetActive(false);
        }
    }
}
