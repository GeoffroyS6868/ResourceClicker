using System.Collections;
using UnityEngine;

public class ResourceCharacterManager : MonoBehaviour
{
    private Resource resourceManaged;
    private int amountFarmed = 0;

    public void StartCharacter(Resource resource)
    {
        resourceManaged = resource;
        amountFarmed = 1;
        StartCoroutine(IncrementEverySecond());
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