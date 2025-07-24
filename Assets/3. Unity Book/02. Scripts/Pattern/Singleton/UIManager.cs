using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    protected override void Awake()
    {
        base.Awake();

        Debug.Log("추가할 기능");
    }
}