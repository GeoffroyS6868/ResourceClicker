using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public Canvas upgradeOverlay;

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if (rayHit.collider != null)
        {
            var worldPosition = rayHit.point;

            if (rayHit.collider.gameObject.TryGetComponent<Resource>(out var resource))
            {
                upgradeOverlay.gameObject.SetActive(false);
                resource.Farmed(worldPosition);
            }
        }
        else
        {
            upgradeOverlay.gameObject.SetActive(false);
        }
    }
    public void Upgrade(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if (rayHit.collider != null)
        {
            var worldPosition = rayHit.point;

            if (rayHit.collider.gameObject.TryGetComponent<Resource>(out var resource))
            {
                resource.DisplayUpgradeMenu(worldPosition);
            }
        }
    }
}
