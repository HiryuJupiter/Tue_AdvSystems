using System.Collections;
using UnityEngine;

public class ClickAndDrag_Constant : MonoBehaviour
{
    Transform dragTarget;
    float distToObject;
    Vector3 dragPositionOffset;

    bool canDrag = true;

    public void EnableDrag (bool enable) => canDrag = enable;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                distToObject = Vector3.Distance(hit.point, ray.origin);

                dragTarget = hit.transform;
                dragPositionOffset = dragTarget.position - hit.point;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragTarget = null;
        }

        if (dragTarget)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 mousePos = ray.origin + ray.direction * distToObject;
            dragTarget.position = mousePos + dragPositionOffset;
        }
    }
}
