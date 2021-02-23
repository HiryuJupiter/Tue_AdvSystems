using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Canvas rect (canvas.GetComponent<RectTransform()).sizeDelta should be the same as 
//the screensize, but not always of course.

//https://forum.unity.com/threads/world-to-screen-point-with-canvas-set-to-scale-with-screen-size.853078/

public class UIFollowMouse : MonoBehaviour
{
    public RectTransform canvasRect;
    RectTransform rect;
    Vector2 uiOffset; //The canvas's middle point is 0,0 instead of bottom left.

    /*
 * PLEASE TRY THIS
 public static Vector3 WorldToScreenSpace(Vector3 worldPos, Camera cam, RectTransform area)
{
    Vector3 screenPoint = cam.WorldToScreenPoint(worldPos);
    screenPoint.z = 0;
 
    Vector2 screenPos;
    if (RectTransformUtility.ScreenPointToLocalPointInRectangle(area, screenPoint, cam, out screenPos))
    {
        return screenPos;
    }
 
    return screenPoint;
 */

    /*
     public class GUIElementFollowWorldSpaceObject : MonoBehaviour
{
    public Transform FollowThis;
    public float OffsetYScreenFraction;
    private Vector3 pos;
 
    void Update()
    {
        pos = Camera.main.WorldToScreenPoint(FollowThis.position);
        pos.y -= Screen.height * OffsetYScreenFraction;
        this.transform.position = pos;
    }
}
     */



    void Start()
    {
        rect = GetComponent<RectTransform>();
        Debug.Log("canvasRect.localScale.x: " + canvasRect.localScale.x + ", canvasRect.localScale.y: " + canvasRect.localScale.y);

        uiOffset = new Vector2(
            canvasRect.sizeDelta.x * 0.5f * (canvasRect.localScale.x * 2f), 
            canvasRect.sizeDelta.y * 0.5f * (canvasRect.localScale.y * 2f));
        //uiOffset = new Vector2(canvsRect.sizeDelta.x * 0.5f, canvsRect.sizeDelta.y * 0.5f);
    }

    void Update()
    {
        rect.localPosition = (Vector2)Input.mousePosition - uiOffset;
        //rect.localPosition = (Vector2)Input.mousePosition - 
            //new Vector2(canvasRect.sizeDelta.x * 0.5f * canvasRect.localScale.x, canvasRect.sizeDelta.y * 0.5f * canvasRect.localScale.y);
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