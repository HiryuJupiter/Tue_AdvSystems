using System.Collections;
using UnityEngine;

public class DragAndDropA : MonoBehaviour
{

    Transform dragObject;
    float distance;

    private void Update()
    {
        DragObject1();
    }

    void DragObject1()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                dragObject = hit.transform;
                distance = Vector3.Distance(hit.transform.position, ray.origin);
                Debug.DrawRay(ray.origin, ray.direction * distance, Color.yellow, 5f);
            }
        }

        if (dragObject)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            dragObject.position = ray.origin + ray.direction * distance;
        }

        if (Input.GetMouseButtonUp(1))
        {
            dragObject = null;
        }
    }
}

//offset = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance));