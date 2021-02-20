using System.Collections;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings Instance;

    [Header("Pinball Machine")]
    public float FlipperForce = 1500f;
    public float FlipperRaisedAngle = 115f;
    public float flipperDamper = 30f;

    [Header("Collision")]
    public float ValidMinimumForce = 4f;

    void Awake()
    {
        Instance = this;
    }
}