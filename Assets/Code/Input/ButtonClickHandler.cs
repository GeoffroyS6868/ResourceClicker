using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{

    public Resource resource;
    public Worker worker;

    public void OnButtonUpgrade()
    {
        if (resource != null)
        {
            resource.BuyUpgrade();
        }
    }

    public void SetResource(Resource newResource)
    {
        resource = newResource;
    }

    public void OnButtonHire()
    {
        if (worker != null)
        {
            worker.Hire();
        }
    }

    public void SetWorker(Worker newWorker)
    {
        worker = newWorker;
    }
}
