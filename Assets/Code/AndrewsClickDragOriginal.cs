using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndrewsClickDragOriginal : MonoBehaviour
{
    public float forceAmmount = 500;

    Rigidbody dragObject;
    Vector3 offset;

    Vector3 orginalPosition;
    float distance;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                distance = Vector3.Distance(ray.origin, hit.point);

                dragObject = hit.rigidbody;
                orginalPosition = hit.collider.transform.position;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragObject = null;
        }

        if (dragObject)
        {
            Vector3 mousePositionOffset = mouseWorldPos - orginalPosition;

            dragObject.velocity = (orginalPosition + mousePositionOffset - dragObject.transform.position) * forceAmmount * Time.deltaTime;
        }
    }

    Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
}


/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndrewsClickDrag : MonoBehaviour
{
    public float forceAmmount = 500;

    Rigidbody dragObject;
    Vector3 offset;

    Vector3 orginalPosition;
    float selectionDistance;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                dragObject = hit.rigidbody;

                selectionDistance = Vector3.Distance(ray.origin, hit.point);
                offset = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance));
                orginalPosition = hit.collider.transform.position;
            }
        }

        if (dragObject)
        {
            Vector3 mousePositionOffset = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance)) - orginalPosition;

            dragObject.velocity = (orginalPosition + mousePositionOffset - dragObject.transform.position) * forceAmmount * Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragObject = null;
        }
    }

}
 */