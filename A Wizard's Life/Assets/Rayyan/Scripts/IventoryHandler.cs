using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class IventoryHandler : MonoBehaviour
{

    [Header("Inventory UI")]
    public float Open_Close;//close= 0 & open=1;
    public float Open_CloseCraft;
    //public GameObject PickUpText;
    [SerializeField] GameObject HandBookUI_Handler;
    [SerializeField] GameObject CraftingUI;

    [Header("InventoryCount")]
    public Text tempText;
    public Text SugarCount;
    public Text DaisiesCount;
    public Text WolfsBaneCount;
    public Text LavaWeedCount;
    public Text WaterCount;
    public Text CoffeeCount;
    public Text ChilliCount;
    public Text SpeedPotionCount;

    [Header("Crafting")]
    public GameObject Potion;
    public GameObject CraftingItem1;
    public GameObject CraftingItem2;
    public int RequiredItemCount1;
    public int RequiredItemCount2;
    public bool CanCraft = false;


    //Narrative things
    public bool hasWater;
    public bool hasCoffeeBeans;
    public Flowchart SpeedPotion;
    public Fungus.Flowchart IntroNarrative;
    public GameObject TutorialInstruction;
    public int Bookcounter;

    private void Update()
    {
        #region Display Inventory
        if (Input.GetKeyDown(KeyCode.I) && Open_Close == 0)
        {
            
            HandBookUI_Handler.SetActive(true);
            StartCoroutine(OpenOrClose());
            string result = "My Iventory: ";

        }
        else if (Input.GetKeyDown(KeyCode.I) && Open_Close == 1)
        {
            StartCoroutine(OpenOrClose());
            HandBookUI_Handler.SetActive(false);
            Bookcounter += 1;
            TutorialInstruction.SetActive(false);
            Debug.Log("It should go away!");

        }
        #endregion
        #region Display Crafting
        if (Input.GetKeyDown(KeyCode.I) && Open_CloseCraft == 0)
        {
            CraftingUI.SetActive(true);
            StartCoroutine(OpenOrCloseCrafting());
            string result = "My Iventory: ";

        }
        else if (Input.GetKeyDown(KeyCode.I) && Open_CloseCraft == 1)
        {
            StartCoroutine(OpenOrCloseCrafting());
            CraftingUI.SetActive(false);
            Bookcounter += 1;
            TutorialInstruction.SetActive(false);
            Debug.Log("It should go away!");

            if (Bookcounter == 2)
            {
                SpeedPotion.ExecuteBlock("Prompt");
            }
            else if (Bookcounter >= 3)
            {
                Bookcounter = 4;
            }
            

        }


        #endregion

        if (IntroNarrative.GetBooleanVariable("mouseLock") == true)  //IntroNarrative.SetBooleanVariable("mouseLock", true))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            // Open_CloseCraft = 0;
            //OpenOrCloseCrafting();
            Debug.Log("AAAAAAA");
        }
        else if (IntroNarrative.GetBooleanVariable("mouseLock") == false)
        {
            //Open_CloseCraft = 0;
            //OpenOrCloseCrafting();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Test Success!");
            Debug.Log(WaterCount.text);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "item")
        {
            AddItem(other.gameObject);
            Item itemHandler = other.GetComponent<Item>();
            itemHandler.Disable();
        }
    }

    #region Add Item To List 
    public void AddItem(GameObject item)
    {
        if(item.name== "Water")
        {
            int ItemCount = 0;
            ItemCount= int.Parse(WaterCount.text);
            ItemCount++;
            WaterCount.text = " " + ItemCount;
            if (ItemCount > 0)
            {
                SpeedPotion.ExecuteBlock("Water");
            }

        }
        if (item.name == "CoffeeBean")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(CoffeeCount.text);
            ItemCount++;
            CoffeeCount.text = " " + ItemCount;

            if (ItemCount > 0)
            {

                SpeedPotion.ExecuteBlock("CoffeeBean");
            }

        }
        if (item.name == "Chilli")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(ChilliCount.text);
            ItemCount++;
            ChilliCount.text = " " + ItemCount;

        }
        if (item.name == "Sugar")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(SugarCount.text);
            ItemCount++;
            SugarCount.text = " " + ItemCount;

        }
        if (item.name == "LavaWeed")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(LavaWeedCount.text);
            ItemCount++;
            LavaWeedCount.text = " " + ItemCount;

        }
        if (item.name == "Daisies")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(DaisiesCount.text);
            ItemCount++;
            DaisiesCount.text = " " + ItemCount;

        }
        if (item.name == "SpeedPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(SpeedPotionCount.text);
            ItemCount++;
            SpeedPotionCount.text = " " + ItemCount;
            SpeedPotion.ExecuteBlock("GotSpeedPotion");
            
        }
    }
    #endregion
    #region Remove Item from List
    void RemoveItem(GameObject item)
    {
        if (item.name == "Water")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(WaterCount.text);
            ItemCount--;
            WaterCount.text = " " + ItemCount;

        }
        if (item.name == "CoffeeBean")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(CoffeeCount.text);
            ItemCount--;
            CoffeeCount.text = " " + ItemCount;

        }
        if (item.name == "Chilli")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(ChilliCount.text);
            ItemCount--;
            ChilliCount.text = " " + ItemCount;

        }
        if (item.name == "Sugar")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(SugarCount.text);
            ItemCount--;
            SugarCount.text = " " + ItemCount;

        }
        if (item.name == "LavaWeed")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(LavaWeedCount.text);
            ItemCount--;
            LavaWeedCount.text = " " + ItemCount;

        }
        if (item.name == "Daisies")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(DaisiesCount.text);
            ItemCount--;
            DaisiesCount.text = " " + ItemCount;

        }
        if (item.name == "SpeedPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(SpeedPotionCount.text);
            ItemCount--;
            SpeedPotionCount.text = " " + ItemCount;

        }
    }
    #endregion
    #region Crafting System
    public void Crafting(GameObject item1, GameObject item2, GameObject Potion, int RequiredCount1, int RequiredCount2)
    {
        int Count1 = 0;
        int Count2 = 0;
        //Text name1;
       // tempText.text = item1.name + "Count";
        //Count1 = int.Parse(tempText.text);
       // tempText.text = item2.name + "Count";
       // Count2 = int.Parse(tempText.text);

        #region item1
        if (item1.name == "Daisies")
        {
            Count1 = int.Parse(DaisiesCount.text);
        }
        else if (item1.name == "Sugar")
        {
            Count1 = int.Parse(SugarCount.text);
        }
        else if (item1.name == "WolfsBane")
        {
            Count1 = int.Parse(WolfsBaneCount.text);
        }
        else if (item1.name == "LavaWeed")
        {
            Count1 = int.Parse(LavaWeedCount.text);
        }
        else if (item1.name == "CoffeeBean")
        {
            Count1 = int.Parse(CoffeeCount.text);
        }
        else if (item1.name == "Water")
        {
            Count1 = int.Parse(WaterCount.text);
        }
        else if (item1.name == "Chilli")
        {
            Count1 = int.Parse(ChilliCount.text);
        }
        #endregion
        #region item2
        if (item2.name == "Daisies")
        {
            Count2 = int.Parse(DaisiesCount.text);
        }
        else if (item2.name == "Sugar")
        {
            Count2 = int.Parse(SugarCount.text);
        }
        else if (item2.name == "WolfsBane")
        {
            Count2 = int.Parse(WolfsBaneCount.text);
        }
        else if (item2.name == "LavaWeed")
        {
            Count2 = int.Parse(LavaWeedCount.text);
        }
        else if (item2.name == "CoffeeBean")
        {
            Count2 = int.Parse(CoffeeCount.text);
        }
        else if (item2.name == "Water")
        {
            Count2 = int.Parse(WaterCount.text);
        }
        else if (item2.name == "Chilli")
        {
            Count2 = int.Parse(ChilliCount.text);
        }
        #endregion        
        CheckItemCount(RequiredCount1, RequiredCount2, Count1, Count2);
        if (CanCraft == true)
        {
            CraftPotion(item1, item2, Potion, RequiredCount1, RequiredCount2);
        }
        else if (CanCraft == false)
        {
            Debug.Log("can not Craft");
        }

    }
    //function Checks if we have enough ingredients to craft 
    void CheckItemCount(int requiredCount1, int requiredCount2, int ItemCount1, int ItemCount2)
    {
        if (ItemCount1 >= requiredCount1 && ItemCount2 >= requiredCount2)
        {
            CanCraft = true;
        }
        else
        {
            CanCraft = false;
        }
    }
    //removes the amount of ingredients to craft and adds the potion we need;
     void CraftPotion(GameObject itemToUse1, GameObject itemToUse2, GameObject PotionToCraft, int obj1, int obj2)
    {
        for (int i = 0; i < obj1; i++)
        {
            RemoveItem(itemToUse1);
        }
        for (int i = 0; i < obj2; i++)
        {
            RemoveItem(itemToUse2);
        }
        AddItem(PotionToCraft);
       
    }
    #endregion
    public void CallCraftSystem()
    {
        Crafting(CraftingItem1, CraftingItem2, Potion, RequiredItemCount1, RequiredItemCount2);
    }
    #region MyRoutines
    IEnumerator OpenOrClose()
    {

        if (Open_Close == 0)
        {
            //Debug.Log("closed");
            Open_Close = 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            yield return null;

            //  yield return new WaitForSeconds(2);
        }
        else
        {
            //Debug.Log("Open");
            Open_Close = 0;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            yield return null;
            //yield return new WaitForSeconds(2);
        }

    }
    IEnumerator OpenOrCloseCrafting()
    {

        if (Open_CloseCraft == 0)
        {
            Debug.Log("this has run");
            //Debug.Log("closed");
            Open_CloseCraft = 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            yield return null;

            //  yield return new WaitForSeconds(2);
        }
        else if (Open_CloseCraft == 1)
        {
            //Debug.Log("Open");
            Open_CloseCraft = 0;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            yield return null;
            //yield return new WaitForSeconds(2);
        }

    }

    #endregion
}

