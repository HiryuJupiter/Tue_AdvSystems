using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropB : MonoBehaviour
{

    private Vector3 screenPoint, offset;

    void OnMouseDown()
    { //Select object
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, screenPoint.z));
    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset - new Vector3(0, 0, -0.8561556f);
        transform.position = curPosition;
    }

}