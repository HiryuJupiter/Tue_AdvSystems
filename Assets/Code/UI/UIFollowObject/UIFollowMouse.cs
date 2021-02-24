using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
public class UIFollowMouse : MonoBehaviour
{
    public Canvas canvas;
    public RectTransform canvasRect;

    RectTransform myRect;

    Vector2 canvasSize;
    Vector2 uiOffset; //The canvas's middle point is 0,0 instead of bottom left.

    void Start()
    {
        myRect = GetComponent<RectTransform>();
        canvasSize = canvasRect.sizeDelta;
        uiOffset = canvasSize * .5f;
    }

    void Update()
    {
        myRect.localPosition = (Vector2)Input.mousePosition / canvas.scaleFactor - uiOffset;
    }
}



/*
 
public class UIFollowMouse : MonoBehaviour
{
    public RectTransform canvasRect;
    RectTransform rect;
    Vector2 uiOffset; //The canvas's middle point is 0,0 instead of bottom left.

    void Start()
    {
        rect = GetComponent<RectTransform>();

        uiOffset = new Vector2(canvasRect.sizeDelta.x * 0.5f * canvasRect.localScale.x, canvasRect.sizeDelta.y * 0.5f * canvasRect.localScale.y);
        //uiOffset = new Vector2(canvsRect.sizeDelta.x * 0.5f, canvsRect.sizeDelta.y * 0.5f);
    }

    void Update()
    {
        //rect.localPosition = (Vector2)Input.mousePosition - uiOffset;
        rect.localPosition = (Vector2)Input.mousePosition - 
            new Vector2(canvasRect.sizeDelta.x * 0.5f * canvasRect.localScale.x, canvasRect.sizeDelta.y * 0.5f * canvasRect.localScale.y);
    }
}

 */