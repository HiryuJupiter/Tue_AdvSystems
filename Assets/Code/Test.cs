using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 2000, 20), "Event.current.mousePosition: " + Event.current.mousePosition);
        GUI.Label(new Rect(20, 40, 2000, 20), "Input.mousePosition        : " + Input.mousePosition);
    }
}