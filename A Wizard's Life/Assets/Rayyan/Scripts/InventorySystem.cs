using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class InventorySystem : MonoBehaviour
{
    [Header("Inventory")]
    public List<GameObject> MyList = new List<GameObject>();
    public GameObject[] PlayerItems;
    public GameObject DummyItem;
    [Header("Inventory UI")]
    public float Open_Close;//close= 0 & open=1;
    public float Open_CloseCraft;
    public GameObject PickUpText;
    [SerializeField] GameObject HandBookUI_Handler;
    [SerializeField] GameObject Crafting;
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


    private void Start()
    {
        MyList.Add(DummyItem);
    }

    #region Pickup Item 
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "item")
        {
            PickUpText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject temp;
                temp = other.gameObject;
                AddItem(temp);
                Item itemHandler = temp.GetComponent<Item>();
                itemHandler.Disable();
            }

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "item" || other.gameObject.tag == null)
        {
            PickUpText.SetActive(false);
        }
    }
    public void AddItem(GameObject currentItem)
    {
        //MyList.RemoveAt(MyList.Count-1);
        MyList.Add(currentItem);
        //MyList.Add(DummyItem);

    }
    public void RemoveItem(GameObject currentItem)
    {
        MyList.Remove(currentItem);

    }
    #endregion
    private void Update()
    {
        #region Display Inventory
        if (Input.GetKeyDown(KeyCode.I) && Open_Close == 0)
        {
            CheckInventory();
            HandBookUI_Handler.SetActive(true);
            StartCoroutine(OpenOrClose());
            string result = "My Iventory: ";

        }
        else if (Input.GetKeyDown(KeyCode.I) && Open_Close == 1)
        {
            StartCoroutine(OpenOrClose());
            HandBookUI_Handler.SetActive(false);
        }
        #endregion
        #region Display Crafting
        if (Input.GetKeyDown(KeyCode.I) && Open_CloseCraft == 0)
        {
            CheckInventory();
            Crafting.SetActive(true);
            StartCoroutine(OpenOrCloseCrafting());
            string result = "My Iventory: ";

        }
        else if (Input.GetKeyDown(KeyCode.I) && Open_CloseCraft == 1)
        {
            StartCoroutine(OpenOrCloseCrafting());
            Crafting.SetActive(false);
        }



            #endregion

            if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Test Success!");
            Debug.Log(WaterCount.text);
            CheckInventory();
        }
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
        #region InventoryCheck Routine
        void CheckInventory()
    {
        //checks how much of each item there is in the iventory 
        foreach (GameObject x in MyList)
        {
            string temp;
            temp = x.name;

            int tempNum = 0;
            string tempString = " ";
         
            for (int i= 0; i<MyList.Count-1 ; i++)
            {
                if (temp == MyList[i].name)
                {  
                    tempNum++;
                }
                else
                {
                    continue;
                }
            }
            if (temp == "Daisies")
            {
                DaisiesCount.text = "0";
                DaisiesCount.text = " " + tempNum;
            }
            else if (temp == "Sugar")
            {
                SugarCount.text = "0";
                SugarCount.text = " " + tempNum;
            }
            else if (temp == "WolfsBane")
            { 
                WolfsBaneCount.text = "0";
                WolfsBaneCount.text = " " + tempNum;
            }
            else if (temp == "LavaWeed")
            {
                LavaWeedCount.text = "0";
                LavaWeedCount.text = " " + tempNum;
            }
            else if (temp == "CoffeeBean")
            {
                CoffeeCount.text = "0";
                CoffeeCount.text = " " + tempNum;
            }
            else if (temp == "Water")
            {
                WaterCount.text = "0";
                WaterCount.text = " " + tempNum;
            }
            else if (temp == "Chilli")
            {
                ChilliCount.text = "0";
                ChilliCount.text = " " + tempNum;
            }
            else if (temp == "SpeedPotion")
            {
                SpeedPotionCount.text = "0";
                SpeedPotionCount.text = " " + tempNum;
            }
        }
    }
    #endregion
    #region Crafting System
    public void CallCraftSystem()
    {
        CraftSystem(CraftingItem1, CraftingItem2, Potion, RequiredItemCount1, RequiredItemCount2);
    }
    public void CraftSystem(GameObject itemToUse1, GameObject itemToUse2, GameObject PotionToCraft, int requiredCount1, int requiredCount2)
    {

        CheckInventory();
        int count1=0;
        int count2=0;
        // CheckItemCount()
        #region item1
        if (itemToUse1.name == "Daisies")
        {
            count1 = int.Parse(DaisiesCount.text);
        }
        else if (itemToUse1.name == "Sugar")
        {
            count1 = int.Parse(SugarCount.text);
        }
        else if (itemToUse1.name == "WolfsBane")
        {
            count1 = int.Parse(WolfsBaneCount.text);
        }
        else if (itemToUse1.name == "LavaWeed")
        {
            count1 = int.Parse(LavaWeedCount.text);
        }
        else if (itemToUse1.name == "CoffeeBean")
        {
            count1 = int.Parse(CoffeeCount.text);
        }
        else if (itemToUse1.name == "Water")
        {
            count1 = int.Parse(WaterCount.text);
        }
        else if (itemToUse1.name == "Chilli")
        {
            count1 = int.Parse(ChilliCount.text);
        }
        #endregion
        #region item2
        if (itemToUse2.name == "Daisies")
        {
            count2 = int.Parse(DaisiesCount.text);
        }
        else if (itemToUse2.name == "Sugar")
        {
            count2 = int.Parse(SugarCount.text);
        }
        else if (itemToUse2.name == "WolfsBane")
        {
            count2 = int.Parse(WolfsBaneCount.text);
        }
        else if (itemToUse2.name == "LavaWeed")
        {
            count2 = int.Parse(LavaWeedCount.text);
        }
        else if (itemToUse2.name == "CoffeeBean")
        {
            count2 = int.Parse(CoffeeCount.text);
        }
        else if (itemToUse2.name == "Water")
        {
            count2 = int.Parse(WaterCount.text);
        }
        else if (itemToUse2.name == "Chilli")
        {
            count2 = int.Parse(ChilliCount.text);
        }
        #endregion        
        CheckItemCount(requiredCount1, requiredCount2, count1, count2);
        if(CanCraft== true)
        {
            CraftPotion(itemToUse1, itemToUse2, PotionToCraft, requiredCount1, requiredCount2);
            Debug.Log("count1=" + count1 + " Req" + RequiredItemCount1);
            Debug.Log("count2=" + count2 + " Req" + RequiredItemCount2);

        }
        else if(CanCraft== false)
        {
            Debug.Log("count1=" + count1 + " Req" + RequiredItemCount1);
            Debug.Log("count2=" + count2 + " Req" + RequiredItemCount2);
            Debug.Log("can not Craft");
        }
        
    }
    public void CraftPotion(GameObject itemToUse1, GameObject itemToUse2, GameObject PotionToCraft, int obj1, int obj2)
    {
        for (int i = 0; i < obj1; i++)
        {
            foreach(GameObject x in MyList)
            {
                if(itemToUse1.name== x.name)
                {
                    MyList.Remove(x);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        for (int i = 0; i < obj2; i++)
        {
            foreach (GameObject x in MyList)
            {
                if (itemToUse2.name == x.name)
                {
                    MyList.Remove(x);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        AddItem(PotionToCraft);
        CheckInventory();
    }
     void CheckItemCount(int requiredCount1, int requiredCount2, int ItemCount1, int ItemCount2)
    {
        if(ItemCount1>= requiredCount1 && ItemCount2>= requiredCount2)
        {
            CanCraft = true;
        }
        else
        {
            CanCraft = false; 
        }
    }
    #endregion

}

