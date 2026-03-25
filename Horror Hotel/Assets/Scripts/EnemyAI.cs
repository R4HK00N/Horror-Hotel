using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float roamRadius = 20f;
    [SerializeField] float sightDistance = 15f;
    [SerializeField] float chaseSpeed = 8f;
    [SerializeField] float roamSpeed = 3f;
    [SerializeField] float catchDistance = 2f;

    NavMeshAgent agent;
    bool playerSeen;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = roamSpeed;
        player = GameObject.FindWithTag("Player").transform;
        SetRoamTarget();
    }

    void Update()
    {
        float distToPlayer = Vector3.Distance(transform.position, player.position);

        if (playerSeen)
        {
            agent.speed = chaseSpeed;
            agent.SetDestination(player.position);
            if (distToPlayer < catchDistance)
            {
                CatchPlayer();
            }
        }
        else
        {
            agent.speed = roamSpeed;
            if (agent.remainingDistance < 1f)
            {
                SetRoamTarget();
            }
        }

        playerSeen = CanSeePlayer();
        if (!playerSeen && distToPlayer > sightDistance) playerSeen = false;

        
        if (Vector3.Distance(transform.position, player.position) < catchDistance)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    bool CanSeePlayer()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        return Physics.Raycast(transform.position + Vector3.up, dir, sightDistance) && Vector3.Distance(transform.position, player.position) <= sightDistance;
    }

    void SetRoamTarget()
    {
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * roamRadius;
        if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, roamRadius, 1))
        {
            agent.SetDestination(hit.position);
        }
    }

    void CatchPlayer()
    {
        Debug.Log("Player caught!");
       
    }
}