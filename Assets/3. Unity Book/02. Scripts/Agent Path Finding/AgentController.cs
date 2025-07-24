using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] points;
    private int index;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(points[index].position);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, points[index].position) < 1.5f)
        {
            index++;

            if (index >= points.Length)
            {
                index = 0;
            }

            agent.SetDestination(points[index].position);            
        }
    }
}
