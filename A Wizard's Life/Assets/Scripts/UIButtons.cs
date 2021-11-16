using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour
{
    public GameObject heatPotionUI;
    public GameObject speedPotionUI;
    public GameObject ShrinkPotionUI;
    public GameObject MeatpotionUi;
    public GameObject DigestivePotionUi;
    public GameObject ColdPotionUI;
    public GameObject GrowthPotionUI;
    public GameObject LinguisticspotionUI;

    public GameObject craftingUI;
    public GameObject inventoryUI;

    public void HeatPotion()
    {
        heatPotionUI.SetActive(true);
        speedPotionUI.SetActive(false);
        ShrinkPotionUI.SetActive(false);
        MeatpotionUi.SetActive(false);
        DigestivePotionUi.SetActive(false);
        GrowthPotionUI.SetActive(false);
        LinguisticspotionUI.SetActive(false);
        ColdPotionUI.SetActive(false);

    }
    public void SpeedPotion()
    {
        heatPotionUI.SetActive(false);
        speedPotionUI.SetActive(true);
        ShrinkPotionUI.SetActive(false);
        MeatpotionUi.SetActive(false);
        DigestivePotionUi.SetActive(false);
        GrowthPotionUI.SetActive(false);
        LinguisticspotionUI.SetActive(false);
        ColdPotionUI.SetActive(false);
    }
    public void ShrinkPotion()
    {
        ShrinkPotionUI.SetActive(true);
        heatPotionUI.SetActive(false);
        speedPotionUI.SetActive(false);
        MeatpotionUi.SetActive(false);
        DigestivePotionUi.SetActive(false);
        GrowthPotionUI.SetActive(false);
        LinguisticspotionUI.SetActive(false);
        ColdPotionUI.SetActive(false);
    }
    public void MeatPotion()
    {
        ShrinkPotionUI.SetActive(false);
        heatPotionUI.SetActive(false);
        speedPotionUI.SetActive(false);
        MeatpotionUi.SetActive(true);
        DigestivePotionUi.SetActive(false);
        GrowthPotionUI.SetActive(false);
        LinguisticspotionUI.SetActive(false);
        ColdPotionUI.SetActive(false);
    }
    public void DigestivePotion()
    {
        ShrinkPotionUI.SetActive(false);
        heatPotionUI.SetActive(false);
        speedPotionUI.SetActive(false);
        MeatpotionUi.SetActive(false);
        DigestivePotionUi.SetActive(true);
        GrowthPotionUI.SetActive(false);
        LinguisticspotionUI.SetActive(false);
        ColdPotionUI.SetActive(false);
    }
    public void ColdPotion()
    {
        ShrinkPotionUI.SetActive(false);
        heatPotionUI.SetActive(false);
        speedPotionUI.SetActive(false);
        MeatpotionUi.SetActive(false);
        DigestivePotionUi.SetActive(false);
        GrowthPotionUI.SetActive(false);
        LinguisticspotionUI.SetActive(false);
        ColdPotionUI.SetActive(true);
    }
    public void LinguisticPotion()
    {
        ShrinkPotionUI.SetActive(false);
        heatPotionUI.SetActive(false);
        speedPotionUI.SetActive(false);
        MeatpotionUi.SetActive(false);
        DigestivePotionUi.SetActive(false);
        GrowthPotionUI.SetActive(false);
        LinguisticspotionUI.SetActive(true);
        ColdPotionUI.SetActive(false);
    }
    public void GrowthPotion()
    {
        ShrinkPotionUI.SetActive(false);
        heatPotionUI.SetActive(false);
        speedPotionUI.SetActive(false);
        MeatpotionUi.SetActive(false);
        DigestivePotionUi.SetActive(false);
        GrowthPotionUI.SetActive(true);
        LinguisticspotionUI.SetActive(false);
        ColdPotionUI.SetActive(false);
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
