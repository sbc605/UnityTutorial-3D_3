using UnityEngine;
using UnityEngine.AI;

public class AgentToRandomPoints : MonoBehaviour
{ 
    private NavMeshAgent agent;
    
    public Transform[] points;
    public int index;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomPoint();
    }

    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Debug.Log("목적지 변경");
            SetRandomPoint();              
        }
    }

    private void SetRandomPoint()
    {
        int temp = index;
        while (temp == index)
            index = Random.Range(0, points.Length);
        
        agent.SetDestination(points[index].position);
    }
}