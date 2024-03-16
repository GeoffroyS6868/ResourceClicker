using UnityEditor;
using UnityEngine;

public static class Utilities
{
    public static Texture2D GetIconFromResourceType(Resource.ResourceType resourceType)
    {
        string path = "Assets/Image/UI/";

        switch (resourceType)
        {
            case Resource.ResourceType.WOOD:
                path += "Wood.png";
                break;
            case Resource.ResourceType.STONE:
                path += "Stone.png";
                break;
            case Resource.ResourceType.PLANK:
                path += "Plank.png";
                break;
            case Resource.ResourceType.GOLD:
                path += "Gold.png";
                break;
        }
        return AssetDatabase.LoadAssetAtPath<Texture2D>(path);
    }
}