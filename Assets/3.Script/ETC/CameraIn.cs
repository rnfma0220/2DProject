using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIn : MonoBehaviour
{
    void Update()
    {
        Canvas canvas = GetComponent<Canvas>();

        if (canvas != null) AssignMainCameraToCanvas();
    }

    private void AssignMainCameraToCanvas()
    {
        Camera mainCamera = Camera.main;
        Canvas canvas = GetComponent<Canvas>();

        if (canvas != null && mainCamera != null)
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = mainCamera;
        }
    }
}
