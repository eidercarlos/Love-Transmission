using UnityEngine;
using System.Collections;
using UnityEngine.AI;

//[RequireComponent(typeof(CharacterController))]

public class Chaser : MonoBehaviour
{   
    public GameObject target;
    NavMeshAgent agent;

    private void Start()
    {   
        //If no target specified, assume the player
        if(target == null)
        {   
            if(GameObject.FindWithTag("Player") != null)
            {   
                target = GameObject.FindWithTag("Player");
            }   
        }   

        agent = GetComponent<NavMeshAgent>();
    }   

    private void Update()
    {   

        if(target != null && target.GetComponent<Health>().isAlive)
        {   
            agent.SetDestination(target.transform.position);
        }   
    }

    // Set the target of the chaser
    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    //public float speed = 0.01f;
    //private Vector3 directionOfPlayer;

    // Use this for initialization
    /*
    void Start()
    {
        // if no target specified, assume the player
        if (target == null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            return;
        }

        directionOfPlayer = target.transform.position - transform.position;
        directionOfPlayer = directionOfPlayer.normalized; 
        transform.Translate(directionOfPlayer * speed, Space.World);
    }

    // Set the target of the chaser
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    */

}
