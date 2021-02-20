using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class UIScoreTextObjectPool
{
    Vector3 offscreen = new Vector3(-100, -100, -100);

    List<GameObject> active = new List<GameObject>();
    List<GameObject> inactive = new List<GameObject>();
    GameObject prefab;
    Transform parent;

    RectTransform canvasRect;

    //Constructor
    public UIScoreTextObjectPool(GameObject prefab, RectTransform canvasRect, Transform parent)
    {
        this.prefab = prefab;
        this.canvasRect = canvasRect;
        this.parent = parent;

        if (prefab.GetComponent<IUITextPoolable>() == null)
        {
            Debug.LogWarning("Object is not a ScoreText");
        }
    }

    public GameObject Spawn(string text, Vector2 targetPosition)
    {
        GameObject p;
        if (inactive.Count > 0)
        {
            //If object pool is not empty, then take an object from the pool and make it active
            p = inactive[0];
            p.SetActive(true);
            inactive.RemoveAt(0);
        }
        else
        {
            //If object pool is empty, then spawn a new object.
            p = GameObject.Instantiate(prefab, targetPosition, Quaternion.identity, parent);
            p.GetComponent<IUITextPoolable>().SetUp(this, canvasRect);
            p.transform.parent = parent;
        }
        p.GetComponent<IUITextPoolable>().Activation(text, targetPosition);
        active.Add(p);
        return p;
    }

    public void Despawn(GameObject obj)
    {
        inactive.Add(obj);
        active.Remove(obj);
        obj.SetActive(false);
    }
}
