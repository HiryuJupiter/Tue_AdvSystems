using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFollowWorldspaceObjSimple : MonoBehaviour
{
    public Transform followTarget;
    RectTransform rect;
    public RectTransform canvasRect;
    public Camera camera;

    Vector2 canvasSize;
    Vector2 offset;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        canvasSize = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y);
        offset = new Vector2(canvasSize.x * 0.5f, canvasSize.y * 0.5f);

        //offset = canvasRect.sizeDelta * 0.5f;
        //Debug.Log("canvasSize: " + canvasRect.sizeDelta);

    }

    void Update()
    {
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(camera, followTarget.position);
        Debug.Log("A: " + screenPos + ", B: " + Camera.main.WorldToViewportPoint(followTarget.position));

        rect.anchoredPosition = screenPos * canvasSize;

    }
}

/*
 Version 1 
    void Update()
    {
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(camera, followTarget.position);
        rect.anchoredPosition = screenPos - offset;
    }
 */


//This one manipulates the anchor which is a bit fishy but it still works
//public class UIFollowWorldspaceObjectDisplayOnWorldspaceCamera : MonoBehaviour
//{
//    public Transform followTarget;
//    RectTransform rect;

//    void Start()
//    {
//        rect = GetComponent<RectTransform>();
//    }

//    void Update()
//    {
//        Vector2 viewPos = Camera.main.WorldToViewportPoint(followTarget.position);
//        rect.anchorMin = rect.anchorMax = viewPos;
//    }
//}
