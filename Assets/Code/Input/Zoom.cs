using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    private readonly float z = 5f;
    public Camera MainCamera;

    void Update()
    {
        MainCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * z;
        if (MainCamera.orthographicSize < 1)
        {
            MainCamera.orthographicSize = 1;
        }
        else if (MainCamera.orthographicSize > 10)
        {
            MainCamera.orthographicSize = 10;
        }
    }
}
