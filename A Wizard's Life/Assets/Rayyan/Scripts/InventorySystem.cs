using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    [Header("Inventory")]
    public List<GameObject> MyList = new List<GameObject>();
    public GameObject[] PlayerItems;
    [Header("Inventory UI")]
    public float Open_Close;//close= 0 & open=1;
    public GameObject PickUpText;
    [SerializeField] GameObject HandBookUI_Handler;
    [Header("InventoryCount")]
    public Text tempText;
    public Text SugarCount;
    public Text DaisiesCount;
    public Text WolfsBaneCount;
    public Text LavaWeedCount;

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
        MyList.Add(currentItem);

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

           /* foreach (GameObject x in MyList)
            {
                string temp;
                temp = x.name;
                result += "\n " + temp.ToString();

            }
            Debug.Log(result);*/
        }
        else if (Input.GetKeyDown(KeyCode.I) && Open_Close == 1)
        {
            StartCoroutine(OpenOrClose());
            HandBookUI_Handler.SetActive(false);

        }
        #endregion

        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Test Success!");
            //CheckInventory();
        }
    }

    #region MyRoutines
    IEnumerator OpenOrClose()
    {

        if (Open_Close == 0)
        {
            //Debug.Log("closed");
            Open_Close = 1;

            yield return null;

            //  yield return new WaitForSeconds(2);
        }
        else
        {
            //Debug.Log("Open");
            Open_Close = 0;

            yield return null;
            //yield return new WaitForSeconds(2);
        }

    }
    #endregion
    #region InventoryCheck Routine
    void CheckInventory()
    {
        foreach (GameObject x in MyList)
        {
            string temp;
            temp = x.name;

            int tempNum = 0;
            string tempString = " ";
         
            for (int i= 0; i<MyList.Count; i++)
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
                DaisiesCount.text = " " + tempNum;
            }
            else if (temp == "Sugar")
            {
                SugarCount.text = " " + tempNum;
            }
            else if (temp == "WolfsBane")
            {
                WolfsBaneCount.text = " " + tempNum;
            }
            else if (temp == "LavaWeed")
            {
                LavaWeedCount.text = " " + tempNum;
            }

        }
    }
    #endregion

}

