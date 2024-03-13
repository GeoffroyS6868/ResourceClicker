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

    private void Start()
    {
        Resource.OnResourceAcquired += HandleResourceAcquired;
    }

    private void HandleResourceAcquired(Resource.ResourceType type)
    {
        switch (type)
        {
            case Resource.ResourceType.WOOD:
                woodAmount++;
                break;
            case Resource.ResourceType.STONE:
                stoneAmount++;
                break;
        }
        UpdateHUD();
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
