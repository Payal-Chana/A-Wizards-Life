using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePotions : MonoBehaviour
{
    public GameObject Player;
    public GameObject Iceberg;
    public GameObject SpeedPotionItem;
    public GameObject HeatPotionItem;
    public GameObject ColdPotionItem;
    public GameObject MeatPotionItem;

    public GameObject ColliderTrigger;

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
    public void ColdPotion()
    {
        if (1 <= int.Parse(inventory.ColdPotionCount.text))
        {
            //Disable Collider and Trigger here
            ColliderTrigger.SetActive(false);
            inventory.RemoveItem(ColdPotionItem);
            Debug.Log("coldUsed");
        }
        else
        {
            Debug.Log("NO ColdPotion");
        }

        
    }
    public void MeatPotion()
    {
        if (1 <= int.Parse(inventory.MeatPotionCount.text))
        {
            inventory.RemoveItem(MeatPotionItem);
            Debug.Log("MeatUsed");
        }
        else
        {
            Debug.Log("NO MEatPotion");
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
