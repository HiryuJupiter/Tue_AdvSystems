using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUIGoToClickedArea : MonoBehaviour
{
    public Canvas canvas;
    RectTransform canvasRect;
    RectTransform myRect;

    Vector2 canvasSize;
    Vector2 uiOffset;
    float scaleFactor;

    void Start()
    {
        myRect = GetComponent<RectTransform>();
        canvasRect = canvas.GetComponent<RectTransform>();

        canvasSize = canvasRect.sizeDelta;
        uiOffset = canvasSize * 0.5f;
        scaleFactor = canvas.scaleFactor;
    }

    public void GoToLocation(Vector3 targetPosition) //Must be vector3 world point!
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(targetPosition) / scaleFactor;
        myRect.localPosition = screenPos - uiOffset;
    }
}
