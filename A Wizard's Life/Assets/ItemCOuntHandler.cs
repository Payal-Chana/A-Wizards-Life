using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCOuntHandler : MonoBehaviour
{

    public GameObject Player;

    IventoryHandler Handler;

    [Header("SpeedPotion")]
    public Text WaterAmount;
    public Text CoffeAmount;

    [Header("ShrinkPotion")]
    public Text SnowFlakeAmount;
    public Text DaisyAmount;
    public Text PineSapAmount;

    [Header("HeatPotion")]
    public Text Water2;
    public Text Chillies;

    [Header("MeatPotion")]
    public Text CorpseFlowerAmount;
    public Text LavaWeedAmount;
    public Text ChilliesAmount;
    public Text Water3;
    public Text LotusAmount;

    [Header("Digestive")]
    public Text Chillies3;
    public Text PineSap2;

    [Header("ColdPotion")]
    public Text IceFlower;
    public Text Water4;

    [Header("GrowthPotion")]
    public Text YetiHairAmout;
    public Text SeedAmount;
    public Text MossAmount;
    public Text IceberriesAmount;

    [Header("LinguiticsPotion")]
    public Text LavaWeed2;
    public Text IceBerries2;
    public Text Chillies4;

    // Start is called before the first frame update
    void Start()
    {
        Handler = Player.GetComponent<IventoryHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        SetSpeedPotionList();
        SetShrinkPotionList();
        SetHeatPotionList();
        SetMeatPotionList();
        SetDigestivePotionList();
        SetColdPotionList();
        SetGrowthPotionText();
        SetLinguiticsPotionList();
    }

    void SetSpeedPotionList()
    {
        WaterAmount.text = Handler.WaterCount.text;
        CoffeAmount.text = Handler.CoffeeCount.text;
        #region Setting Colours
        if (WaterAmount.text == "0")
        {
            WaterAmount.color = Color.red;
        }
        else
        {
            WaterAmount.color = Color.green;
        }
        if (CoffeAmount.text == "0")
        {
            CoffeAmount.color = Color.red;
        }
        else
        {
            CoffeAmount.color = Color.green;
        }
#endregion
    }
    void SetShrinkPotionList()
    {
        SnowFlakeAmount.text = Handler.SnowFlakeCount.text;
        DaisyAmount.text = Handler.DaisiesCount.text;
        PineSapAmount.text = Handler.PineSapCount.text;
        #region Setting Colours

        if (SnowFlakeAmount.text == "0")
        {
            SnowFlakeAmount.color = Color.red;
        }
        else
        {
            SnowFlakeAmount.color = Color.green;
        }
        if (DaisyAmount.text == "0")
        {
            DaisyAmount.color = Color.red;
        }
        else
        {
            DaisyAmount.color = Color.green;
        }
        if (PineSapAmount.text == "0")
        {
            PineSapAmount.color = Color.red;
        }
        else
        {
            PineSapAmount.color = Color.green;
        }
        #endregion
    }

    void SetHeatPotionList()
    {
        Chillies.text = Handler.ChilliCount.text;
        Water2.text = Handler.WaterCount.text;

        #region Setting Colours
        if (Water2.text == "0")
        {
            Water2.color = Color.red;
        }
        else
        {
            Water2.color = Color.green;
        }
        if (Chillies.text == "0" || Chillies.text == "1")
        {
            Chillies.color = Color.red;
        }
        else
        {
            Chillies.color = Color.green;
        }
        #endregion
    }

    void SetMeatPotionList()
    {
        CorpseFlowerAmount.text = Handler.CorspeFlowerCount.text;
        LavaWeedAmount.text = Handler.LavaWeedCount.text;
        ChilliesAmount.text = Handler.ChilliCount.text;
        Water3.text = Handler.WaterCount.text;
        LotusAmount.text = Handler.LotusCount.text;
        #region Setting Colours
        if (CorpseFlowerAmount.text == "0")
        {
            CorpseFlowerAmount.color = Color.red;
        }
        else
        {
            CorpseFlowerAmount.color = Color.green;
        }
        if (ChilliesAmount.text == "0" )
        {
            ChilliesAmount.color = Color.red;
        }
        else
        {
            ChilliesAmount.color = Color.green;
        }
        if (LavaWeedAmount.text == "0")
        {
            LavaWeedAmount.color = Color.red;
        }
        else
        {
            LavaWeedAmount.color = Color.green;
        }
        if (Water3.text == "0")
        {
            Water3.color = Color.red;
        }
        else
        {
            Water3.color = Color.green;
        }
        if (LotusAmount.text == "0")
        {
            LotusAmount.color = Color.red;
        }
        else
        {
            LotusAmount.color = Color.green;
        }
        #endregion
    }

    void SetDigestivePotionList()
    {
        Chillies3.text = Handler.ChilliCount.text;
        PineSap2.text = Handler.PineSapCount.text;
    }
    void SetColdPotionList()
    {
        IceFlower.text = Handler.IceFlowerCount.text;
        Water4.text = Handler.WaterCount.text;

        #region Setting Colours
        if (IceFlower.text == "0")
        {
            IceFlower.color = Color.red;
        }
        else
        {
            IceFlower.color = Color.green;
        }
        if (Water4.text == "0")
        {
            Water4.color = Color.red;
        }
        else
        {
            Water4.color = Color.green;
        }
        #endregion
    }
    void SetGrowthPotionText()
    {
        YetiHairAmout.text = Handler.YetiHairCount.text;
        SeedAmount.text = Handler.SeedCount.text;
        MossAmount.text = Handler.MossCount.text;
        IceberriesAmount.text = Handler.GlowBerriesCount.text;
    }
    void SetLinguiticsPotionList()
    {
        LavaWeed2.text = Handler.LavaWeedCount.text;
        IceBerries2.text = Handler.GlowBerriesCount.text;
        Chillies4.text = Handler.ChilliCount.text;
    }
}
