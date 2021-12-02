using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FungusTriggerThings : MonoBehaviour
{
    public Flowchart YuriFlowchart;
    public Flowchart MargothFlowchart;
    public Flowchart HeliaFlowchart;
    public Flowchart IntroFlowchart;
    public Flowchart OutroFlowchart;
    public Flowchart HeatPotion;
    public Flowchart ColdPotion;
    public Flowchart LoseBook;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Yuri")
        {
            YuriFlowchart.ExecuteBlock("StartYuri");
        }

        if (other.gameObject.tag == "Margoth")
        {
            MargothFlowchart.ExecuteBlock("StartMargoth");
        }

        if (other.gameObject.tag == "Helia")
        {
            HeliaFlowchart.ExecuteBlock("StartHelia");
        }

        if (other.gameObject.tag == "Giddeon")
        {
            IntroFlowchart.ExecuteBlock("StartGiddeonIntro");
        }

        if (other.gameObject.tag == "Giddeon")
        {
            OutroFlowchart.ExecuteBlock("StartGiddeonOutro");
        }

        if (other.gameObject.tag == "IceWall")
        {
            HeatPotion.ExecuteBlock("StartHeatPotion");
        }

        if (other.gameObject.tag == "HotRocks")
        {
            ColdPotion.ExecuteBlock("StartColdPotion");

            /*if (OutroFlowchart.GetBooleanVariable("LostTheBook") == true)
            {
                OutroFlowchart.GetBooleanVariable("LoseBook");
            }
            else
            {

            }*/
        }

        if (other.gameObject.tag == "LoseBook" && LoseBook.GetBooleanVariable("LostTheBook") == true)
        {
            Debug.Log("Lost the book");
            LoseBook.ExecuteBlock("LoseBook");
        }


    }



}
