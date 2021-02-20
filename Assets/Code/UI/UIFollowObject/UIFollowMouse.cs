using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Canvas rect (canvas.GetComponent<RectTransform()).sizeDelta should be the same as 
//the screensize, but not always of course.


public class UIFollowMouse : MonoBehaviour
{
    public RectTransform canvsRect;
    RectTransform rect;
    Vector2 uiOffset; //The canvas's middle point is 0,0 instead of bottom left.

    void Start()
    {
        rect = GetComponent<RectTransform>();

        uiOffset = new Vector2(canvsRect.sizeDelta.x * 0.5f, canvsRect.sizeDelta.y * 0.5f);
    }

    void Update()
    {
        rect.localPosition = (Vector2)Input.mousePosition - uiOffset;
    }
}
