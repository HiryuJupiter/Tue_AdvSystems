using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    private float minForceForScore;

    private float currentScore = 0;

    [SerializeField]
    float forceMultiplier = 0.1f;

    [SerializeField]
    Text text_score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        float forceBeingApplied = 0;

        forceBeingApplied = Mathf.Abs(rb.velocity.magnitude);


        if (forceBeingApplied > minForceForScore)
        {
            currentScore += forceBeingApplied * forceMultiplier * Time.deltaTime;
            
            text_score.text = ((int)currentScore).ToString();
        }
    }
}

/*
 * RAGDOLL
 public class Scoring : MonoBehaviour
{
    List<Joint> joints;

    [SerializeField]
    private float minForceForScore;

    private float currentScore = 0;

    [SerializeField]
    float forceMultiplier = 0.1f;

    [SerializeField]
    Text text_score;

    void Start()
    {
        joints = new List<Joint>(GetComponentsInChildren<Joint>());
        //float forceBeingApplied = joints.currentForce.magnitude;
    }

    void Update()
    {
        float forceBeingApplied = 0;

        foreach(Joint joint in joints)
        {
            forceBeingApplied += joint.currentForce.magnitude;
        }

        if (forceBeingApplied > minForceForScore)
        {
            currentScore += forceBeingApplied * forceMultiplier * Time.deltaTime;
            text_score.text = currentScore.ToString();
        }

        Debug.Log("forceBeingApplied: " + forceBeingApplied);
    }
}
 */