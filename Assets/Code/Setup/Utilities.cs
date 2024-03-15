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
                path += "Wood";
                break;
            case Resource.ResourceType.STONE:
                path += "Stone";
                break;
            case Resource.ResourceType.PLANK:
                path += "Plank";
                break;
            case Resource.ResourceType.GOLD:
                path += "Gold";
                break;
        }
        return AssetDatabase.LoadAssetAtPath<Texture2D>(path);
    }
}