using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using Cinemachine;

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
    public Text HeatPotionCount;
    public Text DaisiesCount;
    public Text WolfsBaneCount;
    public Text LavaWeedCount;
    public Text WaterCount;
    public Text CoffeeCount;
    public Text ChilliCount;
    public Text PineSapCount;
    public Text SnowFlakeCount;
    public Text SpeedPotionCount;
    public Text ShrinkPotionCount;

    [Header("Crafting")]
    public GameObject Potion;
    public GameObject CraftingItem1;
    public GameObject CraftingItem2;
    public GameObject CraftingItem3;
    public int RequiredItemCount1;
    public int RequiredItemCount2;
    public int RequiredItemCount3;
    public bool CanCraft = false;


    //Narrative things
    public bool hasWater;
    public bool hasCoffeeBeans;
    public Flowchart SpeedPotion;
    public Flowchart IntroNarrative;
    public Flowchart HeatPotion;
    public GameObject TutorialInstruction;
    public int Bookcounter;
    public PlayerController playerController;

    [Header("Camera")]
    public CinemachineVirtualCamera Main;
    public CinemachineFreeLook MainCam;
    public Camera GiddeonCam;
  

    private void Update()
    {
        #region Display Inventory
        if (Input.GetKeyDown(KeyCode.I) && Open_Close == 0)
        {
            playerController.canPlayerMove = false;
            MainCam.m_YAxis.m_MaxSpeed = 0;
            MainCam.m_XAxis.m_MaxSpeed = 0;
            HandBookUI_Handler.SetActive(true);
            StartCoroutine(OpenOrClose());
            string result = "My Iventory: ";
        }
        else if (Input.GetKeyDown(KeyCode.I) && Open_Close == 1)
        {
            StartCoroutine(OpenOrClose());
            playerController.canPlayerMove = true;
            MainCam.m_YAxis.m_MaxSpeed = 1.5f;
            MainCam.m_XAxis.m_MaxSpeed = 200;
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
            else if (Bookcounter >= 4)
            {
                Bookcounter = 4;
            }
            

        }


        #endregion
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Open_CloseCraft == 0) // craft is not open
            {
                Application.Quit();
            }
        }
        if (IntroNarrative.GetBooleanVariable("mouseLock") == true) 
        {
            GiddeonCam.gameObject.SetActive(true);
            
            playerController.canPlayerMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (IntroNarrative.GetBooleanVariable("mouseLock") == false && Open_CloseCraft == 0)
        {
            GiddeonCam.gameObject.SetActive(false);
            
            playerController.canPlayerMove = true;
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
            ItemCount= ItemCount + 10;
            WaterCount.text = " " + ItemCount;
            if (ItemCount > 0)
            {
                SpeedPotion.SetBooleanVariable("hasWater", true);

                if (SpeedPotion.GetBooleanVariable("hasCoffeeBeans") == false && SpeedPotion.GetBooleanVariable("hasWater") == true)
                {
                    SpeedPotion.ExecuteBlock("Water");
                }

                else if (SpeedPotion.GetBooleanVariable("hasCoffeeBeans") == true && SpeedPotion.GetBooleanVariable("hasWater") == false)
                {
                    SpeedPotion.ExecuteBlock("Water");
                }
                else if (SpeedPotion.GetBooleanVariable("hasCoffeeBeans") == true && SpeedPotion.GetBooleanVariable("hasWater") == true)
                {
                    SpeedPotion.ExecuteBlock("GotIngredients");
                }

                /*HeatPotion.SetBooleanVariable("hasHeatWater", true);
                Debug.Log("Should get water");
                if (HeatPotion.GetBooleanVariable("hasChillies") == false && HeatPotion.GetBooleanVariable("hasHeatWater") == true)
                {
                    HeatPotion.ExecuteBlock("Water");
                }

                else if (HeatPotion.GetBooleanVariable("hasChillies") == true && HeatPotion.GetBooleanVariable("hasHeatWater") == false)
                {
                    HeatPotion.ExecuteBlock("Chillies");
                }
                else if (HeatPotion.GetBooleanVariable("hasChillies") == true && HeatPotion.GetBooleanVariable("hasHeatWater") == true)
                {
                    HeatPotion.ExecuteBlock("GotHeatIngredients");
                }*/

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
                SpeedPotion.SetBooleanVariable("hasCoffeeBeans", true);

                if (SpeedPotion.GetBooleanVariable("hasCoffeeBeans") == false && SpeedPotion.GetBooleanVariable("hasWater") == true)
                {
                    SpeedPotion.ExecuteBlock("CoffeeBean");
                }

                else if (SpeedPotion.GetBooleanVariable("hasCoffeeBeans") == true && SpeedPotion.GetBooleanVariable("hasWater") == false)
                {
                    SpeedPotion.ExecuteBlock("CoffeeBean");
                }
                else if (SpeedPotion.GetBooleanVariable("hasCoffeeBeans") == true && SpeedPotion.GetBooleanVariable("hasWater") == true)
                {
                    SpeedPotion.ExecuteBlock("GotIngredients");
                }
            
            }

        }
        if (item.name == "Chilli")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(ChilliCount.text);
            ItemCount++;
            ChilliCount.text = " " + ItemCount;

            /*if (ItemCount > 0)
            {
               HeatPotion.SetBooleanVariable("hasChillies", true);
                Debug.Log("Should have chillies");
                if (HeatPotion.GetBooleanVariable("hasChillies") == false && HeatPotion.GetBooleanVariable("hasWater") == true)
                {
                    HeatPotion.ExecuteBlock("Chillies");
                }

                else if (HeatPotion.GetBooleanVariable("hasChillies") == true && HeatPotion.GetBooleanVariable("hasWater") == false)
                {
                    HeatPotion.ExecuteBlock("Chillies");
                }
                else if (HeatPotion.GetBooleanVariable("hasChillies") == true && HeatPotion.GetBooleanVariable("hasWater") == true)
                {
                    HeatPotion.ExecuteBlock("GotHeatIngredients");
                }

            }*/

        }
        if (item.name == "HeatPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(HeatPotionCount.text);
            ItemCount++;
            HeatPotionCount.text = " " + ItemCount;
            HeatPotion.ExecuteBlock("GotHeatPotion");

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
        if (item.name == "ShrinkPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(ShrinkPotionCount.text);
            ItemCount++;
            ShrinkPotionCount.text = " " + ItemCount;
            

        }
        if (item.name == "PineSap")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(PineSapCount.text);
            ItemCount++;
            PineSapCount.text = " " + ItemCount;
            

        }
        if (item.name == "Snowflake")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(SnowFlakeCount.text);
            ItemCount++;
            SnowFlakeCount.text = " " + ItemCount;
            
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
        if (item.name == "HeatPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(HeatPotionCount.text);
            ItemCount--;
            HeatPotionCount.text = " " + ItemCount;

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
        if (item.name == "PineSap")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(PineSapCount.text);
            ItemCount--;
            PineSapCount.text = " " + ItemCount;


        }
        if (item.name == "Snowflake")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(SnowFlakeCount.text);
            ItemCount--;
            SnowFlakeCount.text = " " + ItemCount;

        }
        if (item.name == "SpeedPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(SpeedPotionCount.text);
            ItemCount--;
            SpeedPotionCount.text = " " + ItemCount;

        }
        if (item.name == "ShrinkPotion")
        {
            int ItemCount = 0;
            ItemCount = int.Parse(ShrinkPotionCount.text);
            ItemCount--;
            ShrinkPotionCount.text = " " + ItemCount;

        }
    }
    #endregion
    #region Crafting System
    public void Crafting(GameObject item1, GameObject item2, GameObject item3, GameObject Potion, int RequiredCount1, int RequiredCount2, int RequiredCount3)
    {
        int Count1 = 0;
        int Count2 = 0;
        int Count3 = 0;
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
        else if (item1.name == "Pinesap")
        {
            Count1 = int.Parse(PineSapCount.text);
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
        else if (item1.name == "Snowflake")
        {
            Count1 = int.Parse(SnowFlakeCount.text);
        }
        #endregion
        #region item2
        if (item2.name == "Daisies")
        {
            Count2 = int.Parse(DaisiesCount.text);
        }
        else if (item2.name == "PineSap")
        {
            Count2 = int.Parse(PineSapCount.text);
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
        else if (item2.name == "Snowflake")
        {
            Count2 = int.Parse(SnowFlakeCount.text);
        }
        #endregion  
        #region item3
        if (item3.name == "Daisies")
        {
            Count3 = int.Parse(DaisiesCount.text);
        }
        else if (item3.name == "PineSap")
        {
            Count3 = int.Parse(PineSapCount.text);
        }
        else if (item3.name == "WolfsBane")
        {
            Count3 = int.Parse(WolfsBaneCount.text);
        }
        else if (item3.name == "LavaWeed")
        {
            Count3 = int.Parse(LavaWeedCount.text);
        }
        else if (item3.name == "CoffeeBean")
        {
            Count3 = int.Parse(CoffeeCount.text);
        }
        else if (item3.name == "Water")
        {
            Count3 = int.Parse(WaterCount.text);
        }
        else if (item3.name == "Chilli")
        {
            Count3 = int.Parse(ChilliCount.text);
        }
        else if (item3.name == "Snowflake")
        {
            Count3 = int.Parse(SnowFlakeCount.text);
        }
        #endregion     

        CheckItemCount(RequiredCount1, RequiredCount2, RequiredCount3,Count1, Count2, Count3);
        if (CanCraft == true)
        {
            CraftPotion(item1, item2,item3, Potion, RequiredCount1, RequiredCount2, RequiredCount3);
        }
        else if (CanCraft == false)
        {
            Debug.Log("can not Craft");
            Debug.Log(Count1 + " + " + Count2 + " + " + Count3);
        }

    }
    //function Checks if we have enough ingredients to craft 
    void CheckItemCount(int requiredCount1, int requiredCount2,int requiredCount3, int ItemCount1, int ItemCount2, int ItemCount3)
    {
        if (ItemCount1 >= requiredCount1 && ItemCount2 >= requiredCount2 && ItemCount3 >= requiredCount3)
        {
            CanCraft = true;
        }
        else
        {
            CanCraft = false;
        }
    }
    //removes the amount of ingredients to craft and adds the potion we need;
     void CraftPotion(GameObject itemToUse1, GameObject itemToUse2,GameObject itemToUse3, GameObject PotionToCraft, int obj1, int obj2, int obj3)
    {
        for (int i = 0; i < obj1; i++)
        {
            RemoveItem(itemToUse1);
        }
        for (int i = 0; i < obj2; i++)
        {
            RemoveItem(itemToUse2);
        }
        for (int i = 0; i < obj3; i++)
        {
            RemoveItem(itemToUse3);
        }

        AddItem(PotionToCraft);
       
    }
    #endregion
    public void CallCraftSystem()
    {
        Crafting(CraftingItem1, CraftingItem2,CraftingItem3, Potion, RequiredItemCount1, RequiredItemCount2, RequiredItemCount3);
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
            //Debug.Log("closed");
            Open_CloseCraft = 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            yield return null;

            //  yield return new WaitForSeconds(2);
        }
        else
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

