using System.Collections;
using UnityEngine;

/*
 * This creates inconsistent distance, where the dragTarget is gradually being pulled towards you.
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
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = distToObject;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            dragTarget.position = mousePos + dragPositionOffset;
        }
    }
}
 */
