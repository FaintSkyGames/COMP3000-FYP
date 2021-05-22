using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    public NavMeshAgent agent;

    [SerializeField]
    private Transform[] patrolPath;

    private int nextPathPoint = 0;
    private Vector3 destination;

    private GameObject playerToFollow = null;

    // Start is called before the first frame update
    void Start()
    {
        destination = patrolPath[nextPathPoint].position;
        agent.SetDestination(destination);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerToFollow != null)
        {
            destination = playerToFollow.transform.position;
            agent.SetDestination(destination);
        }

        // If reached desired point, go to next point
        else if (this.transform.position.x == destination.x && this.transform.position.z == destination.z)
        {
            nextPathPoint += 1;

                // Prevent going to a point that doesn't exsist
                if (nextPathPoint == patrolPath.Length)
                {
                    nextPathPoint = 0;
                }

                destination = patrolPath[nextPathPoint].position;
                agent.SetDestination(destination);
        }        
        
    }

    // If player within detection range, follow instead
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (playerToFollow == null)
            {
                playerToFollow = other.gameObject;
                destination = playerToFollow.transform.position;
                agent.SetDestination(destination);
            }
        }
    }

    // If player evades enemy, go back to patrolling
    private void OnTriggerExit(Collider other)
    {
        if (playerToFollow == other.gameObject)
        {
            playerToFollow = null;
            destination = patrolPath[nextPathPoint].position;
            agent.SetDestination(destination);
        }
    }
}
