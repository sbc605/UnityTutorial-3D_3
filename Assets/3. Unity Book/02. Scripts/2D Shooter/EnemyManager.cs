using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public int poolSize = 10;

    // public GameObject[] enemyObjectPool; // 배열
    // public List<GameObject> enemyObjectPool; // 리스트
    public Queue<GameObject> enemyObjectPool; // 큐
    
    public Transform[] spawnPoints;
    
    public GameObject enemyFactory;
    
    private float currentTime; // 타이머
    private float minTime = 1;
    private float maxTime = 5;
    public float createTime = 1f; // 생성 주기
    
    void Start()
    {
        createTime = Random.Range(minTime, maxTime);
        
        // enemyObjectPool =  new GameObject[poolSize]; // 배열
        // enemyObjectPool = new List<GameObject>(); // 리스트
        enemyObjectPool = new Queue<GameObject>(); // 큐
        
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);

            // enemyObjectPool[i] = enemy; // 배열
            // enemyObjectPool.Add(enemy); // 리스트
            enemyObjectPool.Enqueue(enemy); // 큐
            
            enemy.SetActive(false);
        }
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime) // 랜덤한 시간이 될 때 마다 랜덤한 위치에 Enemy 생성
        {
            // 큐
            if (enemyObjectPool.Count > 0)
            {
                currentTime = 0f;
                createTime = Random.Range(minTime, maxTime);

                GameObject enemy = enemyObjectPool.Dequeue();
                
                int ranIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[ranIndex];
                
                enemy.transform.position = spawnPoint.position;
                enemy.SetActive(true);
            }
            
            // 리스트
            // if (enemyObjectPool.Count > 0)
            // {
            //     currentTime = 0f;
            //     createTime = Random.Range(minTime, maxTime);
            //
            //     GameObject enemy = enemyObjectPool[0];
            //     enemyObjectPool.Remove(enemy);
            //     
            //     int ranIndex = Random.Range(0, spawnPoints.Length);
            //     Transform spawnPoint = spawnPoints[ranIndex];
            //     
            //     enemy.transform.position = spawnPoint.position;
            //     enemy.SetActive(true);
            // }

            
            // 배열
            // for (int i = 0; i < poolSize; i++)
            // {
            //     GameObject enemy = enemyObjectPool[i];
            //     
            //     if (!enemy.activeSelf)
            //     {
            //         int ranIndex = Random.Range(0, spawnPoints.Length);
            //         Transform spawnPoint = spawnPoints[ranIndex];
            //         
            //         enemy.transform.position = spawnPoint.position;
            //         enemy.SetActive(true);
            //
            //         break;
            //     }
            // }
        }
    }
}