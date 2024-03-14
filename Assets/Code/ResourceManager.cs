using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    private int woodAmount = 0;
    private int stoneAmount = 0;

    public Text WoodAmountText;
    public Text StoneAmountText;

    public Canvas upgradeOverlay;

    private void Start()
    {
        Resource.OnResourceAcquired += HandleResourceAcquired;
        Resource.OnResourceUpgraded += UpgradeResource;
        upgradeOverlay.gameObject.SetActive(false);
    }

    private void HandleResourceAcquired(Resource.ResourceType type, int gainPerClick)
    {
        switch (type)
        {
            case Resource.ResourceType.WOOD:
                woodAmount += gainPerClick;
                break;
            case Resource.ResourceType.STONE:
                stoneAmount += gainPerClick;
                break;
        }
        UpdateHUD();
    }

    private bool UpgradeResource(Resource.ResourceType type, int price)
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
        }
        UpdateHUD();
        return bought;
    }

    private void UpdateHUD()
    {
        WoodAmountText.text = woodAmount.ToString("0");
        StoneAmountText.text = stoneAmount.ToString("0");
    }

    private void OnDestroy()
    {
        Resource.OnResourceAcquired -= HandleResourceAcquired;
    }
}
