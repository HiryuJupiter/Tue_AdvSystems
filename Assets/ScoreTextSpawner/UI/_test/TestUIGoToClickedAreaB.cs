using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUIGoToClickedAreaB : MonoBehaviour
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

    public void GoToLocation(Vector3 targetPosition)
    {
        Vector2 viewPos = Camera.main.WorldToViewportPoint(targetPosition);
        Vector2 screenPos = new Vector2(viewPos.x * canvasSize.x - uiOffset.x,
            viewPos.y * canvasSize.y - uiOffset.y);

        myRect.localPosition = screenPos ;
    }
}
