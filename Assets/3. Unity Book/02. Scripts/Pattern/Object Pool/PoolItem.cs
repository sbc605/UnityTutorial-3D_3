using UnityEngine;

public class PoolItem : MonoBehaviour
{
    private PoolManager poolManager;
    private bool isInit = false;

    void Awake()
    {
        poolManager = GameObject.FindFirstObjectByType<PoolManager>();
    }

    void OnEnable()
    {
        if (!isInit)
            isInit = true;
        else
            Invoke("ReturnObject", 2f);
    }

    private void ReturnObject()
    {
        poolManager.pool.Release(gameObject);
    }
}