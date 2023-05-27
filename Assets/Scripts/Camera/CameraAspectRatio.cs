using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraAspectRatio : MonoBehaviour
{
    public float targetAspectRatio = 1f;

    private void Start()
    {
        float currentAspectRatio = (float)Screen.width / Screen.height;
        float scaleHeight = currentAspectRatio / targetAspectRatio;

        Camera camera = GetComponent<Camera>();

        // Apply letterboxing/pillarboxing
        if (scaleHeight < 1f)
        {
            Rect rect = camera.rect;
            rect.width = 1f;
            rect.height = scaleHeight;
            rect.x = 0f;
            rect.y = (1f - scaleHeight) / 2f;
            camera.rect = rect;
        }
        else
        {
            // Apply pillarboxing
            float scaleWidth = 1f / scaleHeight;
            Rect rect = camera.rect;
            rect.width = scaleWidth;
            rect.height = 1f;
            rect.x = (1f - scaleWidth) / 2f;
            rect.y = 0f;
            camera.rect = rect;
        }
    }
}

