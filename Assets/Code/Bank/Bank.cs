using System.Diagnostics;
using UnityEngine;
using static Resource;

public class Bank : MonoBehaviour
{
    public BankOverlay Overlay;

    public void DisplayOverlay(Vector2 position)
    {
        Overlay.gameObject.SetActive(true);
        Overlay.transform.position = position;
    }
}