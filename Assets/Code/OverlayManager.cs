using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayManager : MonoBehaviour
{
    public Image IconOne;
    public Image IconTwo;
    public Text PriceOne;
    public Text PriceTwo;
    public Button UpgradeButton;

    public void Start()
    {
        IconOne.gameObject.SetActive(false);
        IconTwo.gameObject.SetActive(false);
        PriceOne.gameObject.SetActive(false);
        PriceTwo.gameObject.SetActive(false);
    }

    public void UpdatePrice(Resource resource, Texture2D icon, int price)
    {
        Sprite sprite = Sprite.Create(icon, new Rect(0, 0, icon.width, icon.height), Vector2.zero);
        IconOne.sprite = sprite;

        PriceOne.text = price.ToString("0");

        var clickHandler = UpgradeButton.GetComponent<ButtonClickHandler>();
        clickHandler.SetResource(resource);

        IconOne.gameObject.SetActive(true);
        PriceOne.gameObject.SetActive(true);
    }
}
