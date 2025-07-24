using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class AgentMouseClick : MonoBehaviour
{
    public Camera camera;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // �ָ��� ��°Ŷ� Infinity ����
            {
                agent.SetDestination(hit.point);
                // agent.destination = hit.point;
            }
        }
    }
}
