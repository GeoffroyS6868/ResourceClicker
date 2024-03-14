using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{

    public Resource resource;
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
}
