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
    }
    void SetShrinkPotionList()
    {
        SnowFlakeAmount.text = Handler.SnowFlakeCount.text;
        DaisyAmount.text = Handler.DaisiesCount.text;
        PineSapAmount.text = Handler.PineSapCount.text;
    }

    void SetHeatPotionList()
    {
        Chillies.text = Handler.ChilliCount.text;
        Water2.text = Handler.WaterCount.text;
    }

    void SetMeatPotionList()
    {
        CorpseFlowerAmount.text = Handler.CorspeFlowerCount.text;
        LavaWeedAmount.text = Handler.LavaWeedCount.text;
        ChilliesAmount.text = Handler.ChilliCount.text;
        Water3.text = Handler.WaterCount.text;
        LotusAmount.text = Handler.LotusCount.text;
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
