using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] Text pullDistance;

    void Awake()
    {
        Instance = this;
    }

    public void SetPullDistance (int amount)
    {
        pullDistance.text = amount.ToString();
    }
}