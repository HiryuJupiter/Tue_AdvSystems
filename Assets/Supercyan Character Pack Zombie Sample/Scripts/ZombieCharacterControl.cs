using UnityEngine;

public class ZombieCharacterControl : MonoBehaviour
{
    private enum ControlMode
    {
        Tank,
        Direct
    }

    [SerializeField] float moveSpeed = 2;
    [SerializeField] float turnSpeed = 200;

    Animator animator;
    Rigidbody rigidBody;
    RagdollSwitch ragdollSwitch;

    [SerializeField] ControlMode controlMode = ControlMode.Tank;

    float currentV = 0;
    float currentH = 0;

    Vector3 currentDir = Vector3.zero;

    void Awake()
    {
        animator = GetComponent<Animator>(); 
        rigidBody = GetComponent<Rigidbody>();
        ragdollSwitch = GetComponent<RagdollSwitch>();
    }

    void FixedUpdate()
    {
        switch (controlMode)
        {
            case ControlMode.Direct:    DirectUpdate();     break;
            case ControlMode.Tank:      TankUpdate();       break;
        }
    }

    void TankUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        currentV = Mathf.Lerp(currentV, v, Time.deltaTime * 10);
        currentH = Mathf.Lerp(currentH, h, Time.deltaTime * 10);

        transform.position += transform.forward * currentV * moveSpeed * Time.deltaTime;
        transform.Rotate(0, currentH * turnSpeed * Time.deltaTime, 0);

        animator.SetFloat("MoveSpeed", currentV);
    }

    void DirectUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Transform camera = Camera.main.transform;

        currentV = Mathf.Lerp(currentV, v, Time.deltaTime * 10);
        currentH = Mathf.Lerp(currentH, h, Time.deltaTime * 10);

        Vector3 direction = camera.forward * currentV + camera.right * currentH;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if (direction != Vector3.zero)
        {
            currentDir = Vector3.Slerp(currentDir, direction, Time.deltaTime * 10);

            transform.rotation = Quaternion.LookRotation(currentDir);
            transform.position += currentDir * moveSpeed * Time.deltaTime;

            animator.SetFloat("MoveSpeed", direction.magnitude);
        }
    }
}
