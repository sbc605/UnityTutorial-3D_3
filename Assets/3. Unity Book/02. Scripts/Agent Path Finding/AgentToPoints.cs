using UnityEngine;
using UnityEngine.AI;

public class AgentToPoints : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform[] points;
    public int index;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(points[index].position);

        if (agent.remainingDistance <= 1.5f) // 목적지와의 거리가 1.5 이하일 경우
        {
            Debug.Log("목적지 변경");
            index++;

            if (index >= points.Length)
                index = 0;
        }
    }
}
