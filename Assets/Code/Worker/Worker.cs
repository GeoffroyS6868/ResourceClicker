using System.Collections;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public WorkerOverlay Overlay;
    private Resource.ResourceType resourceType;
    private Resource resourceManaged;
    private int level = 0;
    private int price = 50;
    private int amountFarmed = 0;
    private bool isBought = false;

    public void Start()
    {
        int randomNumber = Random.Range(0, 2);
        resourceType = (Resource.ResourceType)randomNumber;
        level = Random.Range(1, 5);
        price *= level;
    }

    public void Hire()
    {
        amountFarmed = 1;
        StartCoroutine(IncrementEverySecond());
        isBought = false;
    }

    public void DisplayOverlay(Vector2 position)
    {
        Overlay.gameObject.SetActive(true);
        Overlay.transform.position = position;

        if (!isBought)
        {
            Overlay.UpdateOverlay(price, resourceType);
        }
    }

    public void Upgrade()
    {
        amountFarmed += 1;
    }

    IEnumerator IncrementEverySecond()
    {
        while (true)
        {
            resourceManaged.ManagerFarmed(amountFarmed);
            yield return new WaitForSeconds(1f);
        }
    }
}