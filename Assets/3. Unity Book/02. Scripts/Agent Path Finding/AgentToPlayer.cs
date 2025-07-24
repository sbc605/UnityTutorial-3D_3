using System;
using UnityEngine;
using UnityEngine.AI;

public class AgentToPlayer : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(player.transform.position); // 플레이어를 향해 이동
    }
}
