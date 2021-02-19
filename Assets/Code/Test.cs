using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{

    //void A ()
    //{
    //    Vector3 mouse
    //}

    //void B ()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    Vector3 mouseWorldPos = ray.origin + ray.direction * zOffset;
    //}

    private void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 2000, 20), "Event.current.mousePosition: " + Event.current.mousePosition);
        GUI.Label(new Rect(20, 40, 2000, 20), "Input.mousePosition        : " + Input.mousePosition);
    }
}