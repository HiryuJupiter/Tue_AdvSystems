using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Pool
{
    Vector3 offscreen = new Vector3(-100, -100, -100);

    List<GameObject> active = new List<GameObject>();
    List<GameObject> inactive = new List<GameObject>();
    GameObject prefab;
    Transform parent;

    //Constructor
    public Pool(GameObject prefab, Transform parent)
    {
        this.prefab = prefab;
        this.parent = parent;
        if (prefab.GetComponent<IPoolable>() == null)
        {
            Debug.LogWarning("Object is not a valid IPoolable type");
        }
    }
    public GameObject Spawn()
    {
        GameObject p;
        if (inactive.Count > 0)
        {
            //If object pool is not empty, then take an object from the pool and make it active
            p = inactive[0];
            p.SetActive(true);
            inactive.RemoveAt(0);
            p.GetComponent<IPoolable>().Reactivation();
        }
        else
        {
            //If object pool is empty, then spawn a new object.
            p = GameObject.Instantiate(prefab, offscreen, Quaternion.identity);
            p.GetComponent<IPoolable>().InitialActivation(this);
            p.transform.parent = parent;
        }
        active.Add(p);
        return p;
    }

    public GameObject Spawn(Vector3 pos, Quaternion r)
    {
        GameObject p;
        if (inactive.Count > 0)
        {
            //If object pool is not empty, then take an object from the pool and make it active
            p = inactive[0];
            p.SetActive(true);
            inactive.RemoveAt(0);
            p.GetComponent<IPoolable>().Reactivation();
            p.transform.position = pos;
            p.transform.rotation = r;
        }
        else
        {
            //If object pool is empty, then spawn a new object.
            p = GameObject.Instantiate(prefab, pos, r);
            p.GetComponent<IPoolable>().InitialActivation(this);
            p.transform.parent = parent;
        }
        active.Add(p);
        return p;
    }

    public void Despawn(GameObject obj)
    {
        inactive.Add(obj);
        active.Remove(obj);
        obj.SetActive(false);
    }

    float shortestDist;
    public Transform ClosestUnitToLocation(Vector3 p, ref float detectionDist, ref Transform closest)
    {
        shortestDist = detectionDist;
        foreach (GameObject go in active)
        {
            if (Vector3.SqrMagnitude(p - go.transform.position) < shortestDist)
            {
                closest = go.transform;
                shortestDist = Vector3.SqrMagnitude(p - go.transform.position);
            }
        }
        return closest;
    }
}
