using System.Collections;
using UnityEngine;

public class ScoreSpawnTest : MonoBehaviour
{
    [SerializeField] TestUIGoToClickedArea clickToGo;
    [SerializeField] TestUIGoToClickedAreaB clickToGoB;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //mousePos.
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(r, out RaycastHit hit, float.PositiveInfinity))
            {
                Debug.DrawLine(r.origin, hit.point, Color.red, 10f);
                ScoreTextSpawner.Instance.SpawnScoreText(hit.point, 999);
                clickToGo.GoToLocation(hit.point);
                clickToGoB.GoToLocation(hit.point);
            }
        }
    }
}