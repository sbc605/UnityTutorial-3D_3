using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : Singleton<PlayerFire>
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10;

    // public GameObject[] bulletObjectPool; // 배열
    // public List<GameObject> bulletObjectPool; // 리스트
    public Queue<GameObject> bulletObjectPool; // 큐

    void Start()
    {
        // bulletObjectPool = new GameObject[poolSize]; // 배열
        // bulletObjectPool = new List<GameObject>(); // 리스트
        bulletObjectPool = new Queue<GameObject>(); // 큐

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);

            // bulletObjectPool[i] = bullet; // 배열
            // bulletObjectPool.Add(bullet); // 리스트
            bulletObjectPool.Enqueue(bullet); // 큐

            bullet.SetActive(false);
        }
    }

    void Update()
    {
#if UNITY_STANDARDALONE || UNITY_EDITOR
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("마우스 클릭");
            // 큐
            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;
            }
            
            // 리스트
            // if (bulletObjectPool.Count > 0)
            // {
            //     GameObject bullet = bulletObjectPool[0]; // 가져올 오브젝트 선택
            //     bullet.SetActive(true); // 오브젝트 사용
            //     
            //     bulletObjectPool.Remove(bullet); // Pool에서 오브젝트 제거
            //     
            //     bullet.transform.position = firePosition.transform.position;
            // }
            
            // 배열
            // for (int i = 0; i < poolSize; i++)
            // {
            //     GameObject bullet = bulletObjectPool[i];
            //     
            //     if (!bullet.activeSelf) // 선택한 총알 오브젝트가 비활성화 상태인지 확인
            //     {
            //         bullet.SetActive(true); // 총알을 사용하기 위해 활성화
            //         bullet.transform.position = firePosition.transform.position; // 발사 위치 조정
            //
            //         break; // 반복문 종료
            //     }
            // }
        }
        
#elif UNITY_ANDROID || UNITY_IOS
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("손가락 터치");

            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;
            }
        }
#endif
    }
}