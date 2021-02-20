using System.Collections;
using UnityEngine;

public class HingeFlipperController : MonoBehaviour
{
    [SerializeField] FlapDirections direction;
    [SerializeField] bool logForce;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] Transform addForceDirection;

    //Ref
    HingeJoint hinge;
    Settings settings;

    //Status
    float restAngle;
    JointSpring spring;

    void Awake()
    {
        hinge = GetComponent<HingeJoint>();
    }

    void Start()
    {
        settings = Settings.Instance;
        spring = new JointSpring();
        spring.spring = settings.FlipperForce;
        spring.damper = settings.flipperDamper;
        hinge.spring = spring;
    }

    void Update()
    {
        FlapControl();
    }

    void OnGUI()
    {
        if (logForce)
        {
            //GUI.Label(new Rect(20, 20, 1000, 20), "hinge.velocity: " + hinge.velocity.ToString("0000"));
            //GUI.Label(new Rect(20, 20, 1000, 20), "hinge.velocity: " + string.Format("{0}", hinge.velocity.ToString("D8")));
            //GUI.Label(new Rect(20, 40, 1000, 20), "hinge.currentForce: " + hinge.currentForce.ToString("000000"));
        }
    }

    void AddForce ()
    {
        //hinge.motor.force = Vector3.up * settings.FlipperSpeed;
    }

    void FlapControl()
    {
        if (PressedKey())
            RaiseFlap();
        else
            LowerFlap();
    }

    void RaiseFlap()
    {
        spring.targetPosition = settings.FlipperRaisedAngle;
        hinge.spring = spring;
    }

    void LowerFlap()
    {
        spring.targetPosition = restAngle;
        hinge.spring = spring;
    }

    bool PressedKey()
    {
        switch (direction)
        {
            case FlapDirections.Front:
                return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
            case FlapDirections.Back:
                return Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
            case FlapDirections.Left:
                return Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
            case FlapDirections.Right:
                return Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
            default:
                return false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (hinge.velocity > 20  && IsTargetCharaterLayer(collision))
        {
            collision.collider.GetComponent<Rigidbody>()?.AddForce(addForceDirection.transform.up * hinge.velocity);
        }
    }

    bool IsTargetCharaterLayer (Collision collision) => targetLayer == (targetLayer | 1 << collision.gameObject.layer);
}