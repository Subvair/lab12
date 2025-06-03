using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    private NavMeshAgent[] navAgents;
    public Transform targetMarker;

    void Start()
    {
        navAgents = FindObjectsOfType<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPos = hit.point;
                foreach (var agent in navAgents)
                    agent.destination = targetPos;

                targetMarker.position = targetPos;
            }
        }
    }
}
