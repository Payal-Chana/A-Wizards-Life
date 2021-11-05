using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour
{
    public GameObject heatPotionUI;
    public GameObject speedPotionUI;
    public GameObject craftingUI;
    public GameObject inventoryUI;

    public void HeatPotion()
    {
        heatPotionUI.SetActive(true);
        speedPotionUI.SetActive(false);
    }

    public void SpeedPotion()
    {
        heatPotionUI.SetActive(false);
        speedPotionUI.SetActive(true);
    }

    public void CraftingUIOpen()
    {
        craftingUI.SetActive(true);
        inventoryUI.SetActive(false);
    }

    public void InventoryUIOpen()
    {
        craftingUI.SetActive(false);
        inventoryUI.SetActive(true);
    }
}
