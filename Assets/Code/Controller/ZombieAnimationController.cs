using System.Collections;
using UnityEngine;

public class ZombieAnimationController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2;
    [SerializeField] float turnSpeed = 200;

    Animator animator;
    Rigidbody rigidBody;
    RagdollSwitch ragdollSwitch;

    void Awake()
    {
        animator        = GetComponent<Animator>();
        rigidBody       = GetComponent<Rigidbody>();
        ragdollSwitch   = GetComponent<RagdollSwitch>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToAnimated();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ToRagdoll();
        }
    }

    void ToAnimated()
    {
        ragdollSwitch.TurnOffRagDoll();
    }

    void ToRagdoll()
    {
        ragdollSwitch.TurnOnRagDoll();
    }
}