using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerOverlay : MonoBehaviour
{
    public Image IconOne;
    public Text PriceText;
    public Text LevelText;
    public ResourceManager ResourceManager;

    private Resource.ResourceType resourceType;
    private int price;
    private Worker worker;

    public void UpdateOverlay(int newPrice, Resource.ResourceType newResourceType, int level, Worker newWorker)
    {
        resourceType = newResourceType;
        price = newPrice;
        worker = newWorker;

        Texture2D texture = Utilities.GetIconFromResourceType(resourceType);

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        IconOne.sprite = sprite;

        PriceText.text = newPrice.ToString("0");
        LevelText.text = level.ToString("0");
    }

    public void Hire()
    {
        if (ResourceManager.Buy(Resource.ResourceType.GOLD, price) == true)
        {
            worker.Hire();
            return;
        }
    }
}
