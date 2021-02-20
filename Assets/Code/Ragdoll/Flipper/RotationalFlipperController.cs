using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FlapDirections { Left, Right, Front, Back }

public class RotationalFlapController : MonoBehaviour
{
    //[SerializeField] KeyCode direction;
    [SerializeField] FlapDirections direction;

    Settings settings;

    //Rotations
    float startingX;
    float startingY;
    float startingZ;
    float targetZ;
    float previousZ;
    Quaternion startingRotation;

    void Start()
    {
        startingZ = transform.rotation.z;
        startingY = transform.rotation.y;
        startingX = transform.rotation.x;
        startingRotation = transform.rotation;
        targetZ = startingZ;
        settings = Settings.Instance;
    }

    void Update()
    {
        FlapControl();
    }

    void FlapControl()
    {
        if (PressedKey())
            RaiseFlap();
        else
            LowerFlap();

        if (targetZ != previousZ)
        {
            UpdateRotation();
            previousZ = targetZ;
        }
    }

    void RaiseFlap()
    {
        if (targetZ < settings.FlipperRaisedAngle)
        {
            targetZ += settings.FlipperForce * Time.deltaTime;
            if (targetZ > settings.FlipperRaisedAngle)
                targetZ = settings.FlipperRaisedAngle;
        }
    }

    void LowerFlap ()
    {
        if (targetZ > startingZ)
        {
            targetZ -= settings.FlipperForce * Time.deltaTime;
            if (targetZ < startingZ)
                targetZ = startingZ;
        }
    }

    void UpdateRotation ()
    {
        transform.localRotation = startingRotation * Quaternion.Euler(new Vector3(0f,  0f, targetZ));
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
}
