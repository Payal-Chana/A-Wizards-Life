using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float RespawnTime;
    public GameObject Player;
    InventorySystem inventory;

    private void Awake()
    {
        inventory = Player.GetComponent<InventorySystem>();
    }
    public void Disable()
    {
        //inventory.PickUpText.SetActive(false);
        gameObject.SetActive(false);
    }
}
