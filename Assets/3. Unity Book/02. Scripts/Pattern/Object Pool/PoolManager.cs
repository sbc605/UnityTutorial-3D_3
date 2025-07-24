using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public ObjectPool<GameObject> pool;
    public GameObject prefab;

    void Awake()
    {
        pool = new ObjectPool<GameObject>(CreateObject, OnGetObject, OnReleaseObject); // 생성 -> 꺼내쓰고 -> 집어넣는 기능 가능
    }

    private GameObject CreateObject()
    {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);
        
        return obj;
    }

    private void OnGetObject(GameObject obj) // 꺼내는 기능
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    
        obj.transform.position = Vector3.zero;
        obj.SetActive(true);
    }
    
    private void OnReleaseObject(GameObject obj) // 집어 넣는 기능
    {
        obj.SetActive(false);
    }
    
    private void OnDestroyObject(GameObject obj) // 파괴하는 기능
    {
        Destroy(obj);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = pool.Get(); // Pool에서 오브젝트를 하나 꺼내는 방법
        }
    }
}