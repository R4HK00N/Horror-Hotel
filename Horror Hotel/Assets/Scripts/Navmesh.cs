using UnityEngine;
using UnityEngine.AI;

public class Navmesh : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;

    [SerializeField] float detectionRadius = 10f;
    [SerializeField] float roamRadius = 20f;

    [Header("Stairs")]
    [SerializeField] Transform stairBottom;
    [SerializeField] Transform stairTop;
    [SerializeField] float floorThreshold = 3f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (player == null) player = GameObject.FindWithTag("Player")?.transform;
        SetRandomDestination();
    }

    void Update()
    {
        if (player == null) return;

        float distToPlayer = Vector3.Distance(transform.position, player.position);

        if (distToPlayer < detectionRadius)
        {
            MoveToTarget(player.position);
        }
        else if (agent.remainingDistance < 1f)
        {
            SetRandomDestination();
        }
    }

    void MoveToTarget(Vector3 target)
    {
        if (Mathf.Abs(transform.position.y - target.y) > floorThreshold)
        {
            Transform chosenStair = Random.value > 0.5f ? stairBottom : stairTop;
            agent.SetDestination(chosenStair.position);

            if (Vector3.Distance(transform.position, chosenStair.position) < 2.5f)
            {
                Transform otherStair = (chosenStair == stairBottom) ? stairTop : stairBottom;
                transform.position = otherStair.position + Vector3.up * 0.5f;
                agent.Warp(transform.position);
                agent.SetDestination(target);
            }
        }
        else
        {
            agent.SetDestination(target);
        }
    }

    void SetRandomDestination()
    {
        Vector3 rand = transform.position + Random.insideUnitSphere * roamRadius;
        if (NavMesh.SamplePosition(rand, out NavMeshHit hit, roamRadius, 1))
        {
            MoveToTarget(hit.position);
        }
    }
}