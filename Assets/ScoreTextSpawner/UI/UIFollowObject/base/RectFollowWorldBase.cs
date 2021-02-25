using System.Collections;
using UnityEngine;

public class RectFollowWorldBase : MonoBehaviour
{
    protected Canvas canvas;
    protected RectTransform canvasRect;
    protected RectTransform myRect;

    protected Vector2 canvasSize;
    protected Vector2 uiOffset;
    protected float scaleFactor;

    protected virtual void SetUp(Canvas canvas)
    {
        //Reference
        this.canvas = canvas;
        myRect = GetComponent<RectTransform>();
        canvasRect = canvas.GetComponent<RectTransform>();

        //Cache calculations
        canvasSize = canvasRect.sizeDelta;
        uiOffset = canvasSize * 0.5f;
        scaleFactor = canvas.scaleFactor;
    }

    protected virtual void MoveToTargetWorldPosition(Vector3 targetPosition)
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(targetPosition) / scaleFactor;
        myRect.localPosition = screenPos - uiOffset;

        //Debug.Log(" :" + myRect.anchoredPosition);
    }
}