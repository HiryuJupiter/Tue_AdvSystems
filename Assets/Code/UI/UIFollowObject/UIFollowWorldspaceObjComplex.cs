using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFollowWorldspaceObjComplex : MonoBehaviour
{
    public RectTransform canvsRect;
    public Transform followTarget;
    public Camera worldCamera;
    RectTransform rect;

    Vector2 canvasSize;
    Vector2 uiOffset;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        canvasSize = new Vector2(canvsRect.sizeDelta.x, canvsRect.sizeDelta.y);
        uiOffset = new Vector2(canvasSize.x * 0.5f, canvasSize.y * 0.5f);
    }

    void Update()
    {
        //Just use Camera.main instead of world camera
        Vector2 viewPos = worldCamera.WorldToViewportPoint(followTarget.position);
        Vector2 screenPos = new Vector2(viewPos.x * canvasSize.x - uiOffset.x,
            viewPos.y * canvasSize.y - uiOffset.y);

        //Both of the following seems to work!
        //rect.localPosition = screenPos;
        rect.anchoredPosition = screenPos;
    }
}

