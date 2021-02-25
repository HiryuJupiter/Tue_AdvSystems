using System.Collections;
using UnityEngine;

public interface IUITextPoolable
{
    void SetUp(UIScoreTextObjectPool pool, Canvas canvas);
    void Activation(string text, Vector3 targetPosition);
}
