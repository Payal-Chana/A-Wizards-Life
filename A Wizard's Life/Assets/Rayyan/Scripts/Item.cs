using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    public GameObject Player;
    IventoryHandler inventory;
    public float RespawnItemTime = 0f;

    private void Awake()
    {
        inventory = Player.GetComponent<IventoryHandler>();
    }
    public void Disable()
    {
        inventory.PickUpText.SetActive(false);
        gameObject.SetActive(false);
    }
    // Use this to allow item to respawn in world ( gowth effect )
/*
    public IEnumerator DisableToGrowBack()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(RespawnItemTime);
        gameObject.SetActive(true);
    }*/
}
