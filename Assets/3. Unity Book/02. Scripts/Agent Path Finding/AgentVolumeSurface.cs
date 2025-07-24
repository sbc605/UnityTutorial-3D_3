using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class AgentVolumeSurface : MonoBehaviour
{
    public Camera camera;
    private NavMeshAgent agent;
    public NavMeshSurface surface;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        surface.transform.position = transform.position;
        surface.BuildNavMesh();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // 멀리서 쏘는거라 Infinity 붙음
            {
                agent.SetDestination(hit.point);
            }
        }

        if (Vector3.Distance(transform.position, surface.transform.position) > 4f)
        {
            surface.transform.position = agent.transform.position;
            surface.BuildNavMesh();
        }
    }
}
