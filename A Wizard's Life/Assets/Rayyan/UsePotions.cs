using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePotions : MonoBehaviour
{
    public GameObject Player;
    public GameObject Iceberg;
    public GameObject SpeedPotionItem;
    public GameObject HeatPotionItem;


    IventoryHandler inventory;
    PlayerController controller;
    ShrinkObject melter;
    
    bool InMeltTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Player.GetComponent<IventoryHandler>();
        controller = Player.GetComponent<PlayerController>();
        melter = Iceberg.GetComponent<ShrinkObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpeedPotion()
    {
        if (1 <= int.Parse(inventory.SpeedPotionCount.text))
        {
            controller.SpeedPotion_Used = true;
            inventory.RemoveItem(SpeedPotionItem);
        }
        else
        {
            Debug.Log("NO SpeedPotion");
        }
       
    }
    public void HeatPotion()
    {
        if (InMeltTrigger)
        {
            if (1 <= int.Parse(inventory.HeatPotionCount.text))
            {
                melter.Melting = true;
                inventory.RemoveItem(HeatPotionItem);
            }
            else
            {
                Debug.Log("NO HeatPotion");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "MeltTrigger")
        {
            InMeltTrigger = true;
        }
    }
}
