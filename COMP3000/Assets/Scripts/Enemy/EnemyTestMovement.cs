using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTestMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject gameObj;
    public Transform[] path;
    private int pathPoint;
    private Vector3 destination;
    public Collider detection;


    // Start is called before the first frame update
    void Start()
    {
        pathPoint = 0;
        destination = path[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x == destination.x && this.transform.position.z == destination.z)
        {
            pathPoint += 1;
            if (pathPoint == path.Length)
            {
                pathPoint = 0;
            }
            destination = path[pathPoint].position;
        }

        if (detection.bounds.Contains(gameObj.transform.position))
        {
            //Debug.Log("Inside Sphere");
            destination = gameObj.transform.position;
        }
        else
        {
            destination = path[pathPoint].position;
        }

        agent.SetDestination(destination);
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Entered" + collision.gameObject.layer);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("Exit");
    }
}
