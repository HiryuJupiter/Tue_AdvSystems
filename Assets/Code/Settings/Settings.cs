using System.Collections;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings Instance;

    public float FlapSpeed = 100f;
    public float FlapRaisedAngle = 90f;

    void Awake()
    {
        Instance = this;
    }
}