using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollBrain : MonoBehaviour
{
    static int TotalScore;

    [SerializeField] Transform teleportRoot;
    

    Settings settings;
    ScoreTextSpawner scoreSpawner;
    UIManager ui;

    public void Teleport (Vector3 vector3)
    {
        teleportRoot.transform.position = vector3;
    }

    void Awake()
    {
        //Initialize ragdoll parts
        foreach (var part in GetComponentsInChildren<RagdollParts>())
        {
            part.SetBrainReference(this);
        }
    }

    void Start()
    {
        settings = Settings.Instance;
        scoreSpawner = ScoreTextSpawner.Instance;
        ui = UIManager.Instance;
    }

    public void HitsObject(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > settings.ValidMinimumForce)
        {
            int impactScore = 100 * Mathf.RoundToInt(collision.relativeVelocity.magnitude);
            TotalScore += impactScore;
            ui.SetTotalScore(TotalScore);

            //Pop-up text
            scoreSpawner.SpawnScoreText(collision.contacts[0].point, impactScore);
            
        }
    }
}
