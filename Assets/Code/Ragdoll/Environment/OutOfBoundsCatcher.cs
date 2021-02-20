using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsCatcher : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;
    [SerializeField] LayerMask dollLayer;

    void OnTriggerEnter(Collider collider)
    {
        if (IsTargetCharaterLayer(collider))
        {
            //collider.transform.root.position = respawnPoint.position;
            collider.GetComponent<RagdollParts>()?.Teleport(respawnPoint.position);
        }
    }

    bool IsTargetCharaterLayer(Collider collider) => dollLayer == (dollLayer | 1 << collider.gameObject.layer);
}