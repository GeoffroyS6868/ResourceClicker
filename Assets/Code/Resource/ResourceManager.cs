using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    private int woodAmount = 0;
    private int stoneAmount = 0;
    private int plankAmount = 0;
    private int goldAmount = 0;
    private int refinedOreAmount = 0;

    public Text WoodAmountText;
    public Text StoneAmountText;
    public Text PlankAmountText;
    public Text GoldAmountText;
    public Text RefinedOreAmountText;

    public Canvas upgradeOverlay;

    private void Start()
    {
        Resource.OnResourceAcquired += HandleResourceAcquired;
        Resource.OnResourceUpgraded += Buy;
        upgradeOverlay.gameObject.SetActive(false);
    }

    private bool HandleResourceAcquired(Resource.ResourceType type, int gainPerClick)
    {
        var farmed = false;
        switch (type)
        {
            case Resource.ResourceType.WOOD:
                woodAmount += gainPerClick;
                farmed = true;
                break;
            case Resource.ResourceType.STONE:
                stoneAmount += gainPerClick;
                farmed = true;
                break;
            case Resource.ResourceType.PLANK:
                if (woodAmount >= gainPerClick * 2)
                {
                    woodAmount -= (gainPerClick * 2);
                    plankAmount += gainPerClick;
                    farmed = true;
                }
                break;
            case Resource.ResourceType.REFINED_ORE:
                if (stoneAmount >= 2 * gainPerClick) // Ici, je suppose que 3 unités de pierre donnent 1 minerai raffiné
                {
                    stoneAmount -= 2 * gainPerClick; // Consomme de la pierre pour créer du minerai raffiné
                    refinedOreAmount += gainPerClick; // Ajoutez la logique pour déterminer la quantité de minerai ajouté
                    farmed = true;
                }
            break;
        }
        UpdateHUD();
        return farmed;
    }

    public int GetResourceAmount(Resource.ResourceType type)
    {
        switch (type)
        {
            case Resource.ResourceType.WOOD:
                return woodAmount;
            case Resource.ResourceType.STONE:
                return stoneAmount;
            case Resource.ResourceType.PLANK:
                return plankAmount;
            case Resource.ResourceType.GOLD:
                return goldAmount;
            case Resource.ResourceType.REFINED_ORE:
                return refinedOreAmount;
            default:
                break;
        }
        return 0;
    }

    public bool Buy(Resource.ResourceType type, int price)
    {
        var bought = false;
        switch (type)
        {
            case Resource.ResourceType.WOOD:
                if (woodAmount >= price)
                {
                    woodAmount -= price;
                    bought = true;
                }
                break;
            case Resource.ResourceType.STONE:
                if (stoneAmount >= price)
                {
                    stoneAmount -= price;
                    bought = true;
                }
                break;
            case Resource.ResourceType.PLANK:
                if (plankAmount >= price)
                {
                    plankAmount -= price;
                    bought = true;
                }
                break;
            case Resource.ResourceType.GOLD:
                if (goldAmount >= price)
                {
                    goldAmount -= price;
                    bought = true;
                }
                break;
        }
        UpdateHUD();
        return bought;
    }


    public void SellResource(Resource.ResourceType type, int amount)
    {
        switch (type)
        {
            case Resource.ResourceType.WOOD:
                if (woodAmount >= amount)
                {
                    woodAmount -= amount;
                    goldAmount += (5 * amount);
                }
                break;
            case Resource.ResourceType.STONE:
                if (stoneAmount >= amount)
                {
                    stoneAmount -= amount;
                    goldAmount += (5 * amount);
                }
                break;
            case Resource.ResourceType.PLANK:
                if (plankAmount >= amount)
                {
                    plankAmount -= amount;
                    goldAmount += (15 * amount);
                }
                break;
            case Resource.ResourceType.REFINED_ORE:
                if (refinedOreAmount >= amount)
                {
                    refinedOreAmount -= amount;
                    goldAmount += (15 * amount); 
                }
                break;
        }
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        WoodAmountText.text = woodAmount.ToString("0");
        StoneAmountText.text = stoneAmount.ToString("0");
        PlankAmountText.text = plankAmount.ToString("0");
        GoldAmountText.text = goldAmount.ToString("0");
        RefinedOreAmountText.text = refinedOreAmount.ToString("0");
    }

    private void OnDestroy()
    {
        Resource.OnResourceAcquired -= HandleResourceAcquired;
    }
}
