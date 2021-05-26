using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject model;
    private Animator anim;

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

        anim = model.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = agent.remainingDistance;
        
        if (agent.remainingDistance == 0 && !agent.isStopped)
        {
            Debug.Log("Reached end");

            agent.updatePosition = false;
            agent.updateRotation = false;

            //agent.isStopped = true;
            //anim.SetBool("TurnRight", true);

            if (playerToFollow != null)
            {
                destination = playerToFollow.transform.position;
            }
            else // If reached desired point, go to next point
            {
                nextPathPoint += 1;

                // Prevent going to a point that doesn't exsist
                if (nextPathPoint == patrolPath.Length)
                {
                    nextPathPoint = 0;
                }

                destination = patrolPath[nextPathPoint].position;

                //Turn();
            }

            //agent.isStopped = true;
        }

        
        
            Turn();
        

        agent.updatePosition = true;
        agent.updateRotation = true;

        agent.SetDestination(destination);

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
                Turn();
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
            Turn();
            agent.SetDestination(destination);
        }
    }
    
    private IEnumerator Turn()
    {
        //this.transform.LookAt(destination, Vector3.up);


        Vector3 lookrotation = agent.steeringTarget - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), 30 * Time.deltaTime);

        //agent.isStopped = false;
        return null;
    }

}
