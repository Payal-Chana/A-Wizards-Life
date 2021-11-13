using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour
{
    public GameObject heatPotionUI;
    public GameObject speedPotionUI;
    public GameObject ShrinkPotionUI;
    public GameObject craftingUI;
    public GameObject inventoryUI;

    public void HeatPotion()
    {
        heatPotionUI.SetActive(true);
        speedPotionUI.SetActive(false);
        ShrinkPotionUI.SetActive(false);
    }

    public void SpeedPotion()
    {
        heatPotionUI.SetActive(false);
        speedPotionUI.SetActive(true);
        ShrinkPotionUI.SetActive(false);
    }
    public void ShrinkPotion()
    {
        ShrinkPotionUI.SetActive(true);
        heatPotionUI.SetActive(false);
        speedPotionUI.SetActive(false);
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
