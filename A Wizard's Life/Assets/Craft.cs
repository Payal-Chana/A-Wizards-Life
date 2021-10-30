using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    //Will Use to Set variables in InventorySystem
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Potion;
    public int RequiredCount1;
    public int RequiredCount2;

    public GameObject Player;
    InventorySystem PlayerInventory;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInventory = Player.GetComponent<InventorySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCraftButton()
    {
        PlayerInventory.CraftingItem1 = Item1;
        PlayerInventory.CraftingItem2 = Item2;
        PlayerInventory.Potion = Potion;

        PlayerInventory.RequiredItemCount1 = RequiredCount1;
        PlayerInventory.RequiredItemCount2 = RequiredCount2;

        
    }
    
}
