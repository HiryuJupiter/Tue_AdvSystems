using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] Text totalScoreText;

    void Awake()
    {
        Instance = this;
    }

    public void SetTotalScore(int amount)
    {
        totalScoreText.text = amount.ToString();
    }
}