using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FungusTriggerThings : MonoBehaviour
{
    public Flowchart YuriFlowchart;
    public Flowchart MargothFlowchart;
    public Flowchart HeliaFlowchart;

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

    }



}
