using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankOverlay : MonoBehaviour
{
    public ResourceManager ResourceManager;
    public int divider = 1;
    public Resource.ResourceType resourceType = Resource.ResourceType.WOOD;
    public Text GoldReceivedText;

    public void Sell()
    {
        var resourceAmount = ResourceManager.GetResourceAmount(resourceType);
        int amountToSell = resourceAmount / divider;
        ResourceManager.SellResource(resourceType, amountToSell);
        this.gameObject.SetActive(false);
    }

    public void SetWoodType()
    {
        resourceType = Resource.ResourceType.WOOD;
        UpdateGoldReceive();
    }

    public void SetStoneType()
    {
        resourceType = Resource.ResourceType.STONE;
        UpdateGoldReceive();
    }

    public void SetPlankType()
    {
        resourceType = Resource.ResourceType.PLANK;
        UpdateGoldReceive();
    }

    public void SetRefinedOreType()
    {
    resourceType = Resource.ResourceType.REFINED_ORE;
    UpdateGoldReceive();
    }

    public void SetDividerQuarter()
    {
        divider = 4;
        UpdateGoldReceive();
    }

    public void SetDividerHalf()
    {
        divider = 2;
        UpdateGoldReceive();
    }

    public void SetDividerAll()
    {
        divider = 1;
        UpdateGoldReceive();
    }

    public void UpdateGoldReceive()
    {
        var resourceAmount = ResourceManager.GetResourceAmount(resourceType);
        int amountToSell = resourceAmount / divider;
        if (resourceType == Resource.ResourceType.PLANK || resourceType == Resource.ResourceType.REFINED_ORE)
        {
            amountToSell *= 15;
        }
        else
        {
            amountToSell *= 5;
        }
        GoldReceivedText.text = amountToSell.ToString("0");
    }
}
