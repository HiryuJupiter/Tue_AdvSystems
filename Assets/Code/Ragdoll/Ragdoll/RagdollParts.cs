using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollParts : MonoBehaviour
{
    const float CollisionIntervalCooldown = .5f;

    static bool CanCollide = true;

    RagdollBrain brain;
    Settings settings;

    public void SetBrainReference (RagdollBrain brain)
    {
        this.brain = brain;
    }

    public void Teleport (Vector3 vector3)
    {
        brain.Teleport(vector3);
    }

    void Start()
    {
        settings = Settings.Instance;
    }

    void Update()
    {


    }

    void OnCollisionEnter(Collision collision)
    {
        //If not hitting another ragdoll part...
        if (transform.root != collision.transform.root)
        {
    
            {
                StartCoroutine(Cooldown());
                brain.HitsObject(collision);
            }
        }
    }

    IEnumerator Cooldown ()
    {
        CanCollide = false;
        yield return new WaitForSeconds(CollisionIntervalCooldown);
        CanCollide = true;
    }
}
