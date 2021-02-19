using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//There are 2 ways to turn off rag doll - 
// setting the children colliders to trigger or turning them off.
public class RagdollSwitch : MonoBehaviour
{
    List<Collider> childrenColliders = new List<Collider>();
    Collider myCollider;

    void Awake()
    {
        myCollider = GetComponent<Collider>();

        //Reference and turn off ragdoll 
        Collider[] cols = GetComponentsInChildren<Collider>();
        foreach (var c in cols)
        {
            c.enabled = false;
            //c.isTrigger = true;
            childrenColliders.Add(c);
        }
    }

    public void TurnOffRagDoll ()
    {
        SetChildrenCollidersActive(false);

    }

    public void TurnOnRagDoll ()
    {
        SetChildrenCollidersActive(true);
    }

    void SetChildrenCollidersActive (bool isActive)
    {
        foreach (var c in childrenColliders)
        {
            c.enabled = isActive;
            //c.isTrigger = false;
        }
    }

}
