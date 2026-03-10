using UnityEngine;
using UnityEngine.AI;

public class Navmesh : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    [SerializeField] float detectionRadius = 10f;
    [SerializeField] float roamRadius = 20f;
    private bool isChasingPlayer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (player == null) player = GameObject.FindWithTag("Player")?.transform;
        SetRandomDestination();
        isChasingPlayer = false;
    }

    void Update()
    {
        if (player == null) return;

        float distToPlayer = Vector3.Distance(transform.position, player.position);
        bool wantsToChase = distToPlayer < detectionRadius;

        if (wantsToChase)
        {
            agent.SetDestination(player.position);
            isChasingPlayer = true;
        }
        else
        {
            if (isChasingPlayer || agent.remainingDistance < 1f)
            {
                SetRandomDestination();
                isChasingPlayer = false;
            }
        }
    }

    void SetRandomDestination()
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = transform.position + Random.insideUnitSphere * roamRadius;
            if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, roamRadius, 1))
            {
                agent.SetDestination(hit.position);
                return;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (agent && agent.isActiveAndEnabled)
        {
            Gizmos.color = isChasingPlayer ? Color.red : Color.yellow;
            Gizmos.DrawLine(transform.position, agent.destination);
            Gizmos.DrawWireSphere(agent.destination, 1f);
        }
    }
}