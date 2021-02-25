using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is not that great because it only works on the object that it is attached to. It works for a quick test.
public class DragAndDrop_MouseMouseDrag : MonoBehaviour
{
    private Vector3 myPositionOnScreen;
    private Vector3 dragPositionOffset;

    void OnMouseDown()
    { 
        myPositionOnScreen = Camera.main.WorldToScreenPoint(transform.position);
        dragPositionOffset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, myPositionOnScreen.z));
    }
    void OnMouseDrag()
    {
        Vector3 mouseScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, myPositionOnScreen.z);
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPoint) + dragPositionOffset - new Vector3(0, 0, -0.8561556f);
        transform.position = mouseWorldPos;
    }
}