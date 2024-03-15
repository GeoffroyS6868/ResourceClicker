using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerOverlay : MonoBehaviour
{
    public Texture2D ResourceIcon;
    public Image IconOne;
    public Text PriceText;

    public void UpdateOverlay(int amount, Resource.ResourceType resourceType)
    {
        ResourceIcon = Utilities.GetIconFromResourceType(resourceType);

        Sprite sprite = Sprite.Create(ResourceIcon, new Rect(0, 0, ResourceIcon.width, ResourceIcon.height), Vector2.zero);
        IconOne.sprite = sprite;

        PriceText.text = amount.ToString("0");
    }
}
