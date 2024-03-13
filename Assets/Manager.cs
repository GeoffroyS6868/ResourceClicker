using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text ClicksTotalText;

    float TotalClicks;

    public void AddClicks()
    {
        TotalClicks++;
        ClicksTotalText.text = TotalClicks.ToString("0");
    }
}
