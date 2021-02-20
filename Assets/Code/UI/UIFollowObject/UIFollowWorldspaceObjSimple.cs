using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFollowWorldspaceObjSimple : MonoBehaviour
{
    public Transform followTarget;
    RectTransform rect;
    public RectTransform canvasRect;

    Vector2 offset;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        offset = canvasRect.sizeDelta * 0.5f;
    }

    void Update()
    {
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, followTarget.position);
        rect.anchoredPosition = screenPos - offset;
    }
}


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
