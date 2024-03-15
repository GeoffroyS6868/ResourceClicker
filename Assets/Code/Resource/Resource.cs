using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    public enum ResourceType
    {
        WOOD,
        STONE,
        PLANK,
        GOLD
    }

    public ResourceType Type;

    public ParticleSystem HitParticles;

    public delegate void ResourceAcquiredEventHandler(ResourceType type, int gainPerClick);

    public static event ResourceAcquiredEventHandler OnResourceAcquired;

    public delegate bool ResourceUpgradedEventHandler(ResourceType type, int price);

    public static event ResourceUpgradedEventHandler OnResourceUpgraded;

    public delegate void ResourceSoldEventHandler(ResourceType type);

    public static event ResourceSoldEventHandler OnResourceSold;

    public Texture2D Icon;

    private int level = 0;
    private int gainPerClick = 1;

    private int actualPrice = 50;
    private readonly int priceMultiplier = 50;

    public Canvas upgradeOverlay;

    public void Farmed(Vector2 position)
    {
        OnResourceAcquired?.Invoke(Type, gainPerClick);
        if (HitParticles != null)
        {
            var TempHitParticles = Instantiate(HitParticles);
            TempHitParticles.transform.position = position;
            TempHitParticles.Play();
            Destroy(TempHitParticles.gameObject, TempHitParticles.main.duration * 1.1f);
        }
    }

    public void ManagerFarmed(int amountFarmed)
    {
        OnResourceAcquired?.Invoke(Type, amountFarmed);
    }

    public void DisplayUpgradeMenu(Vector2 position)
    {
        upgradeOverlay.transform.position = position;

        var overlayManager = upgradeOverlay.GetComponent<ResourceUpgraderOverlay>();
        overlayManager.UpdatePrice(this, Icon, actualPrice);

        upgradeOverlay.gameObject.SetActive(true);
    }

    public void BuyUpgrade()
    {
        var bought = OnResourceUpgraded?.Invoke(Type, actualPrice);

        if (bought == null) return;
        if (bought != true) return;

        level += 1;
        gainPerClick += 1;
        actualPrice += level * priceMultiplier;

        upgradeOverlay.gameObject.SetActive(false);
    }

    public void Sell()
    {
        OnResourceSold?.Invoke(Type);
    }

}
