using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject spawnPrefab;

    public float minSecondsBetweenSpawning = 5.0f;
    public float maxSecondsBetweenSpawning = 10.0f;

    public GameObject chaseTarget;

    private float savedTime;
    private float secondsBetweenSpawning;

    // Use this for initialization
    void Start()
    {
        savedTime = Time.time;
        secondsBetweenSpawning = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);

        if(chaseTarget == null)
        {
            if(GameObject.FindWithTag("Player") != null)
            {
                chaseTarget = GameObject.FindWithTag("Player");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - savedTime >= secondsBetweenSpawning) // is it time to spawn again?
        {
            MakeThingToSpawn();
            savedTime = Time.time; // store for next spawn
            secondsBetweenSpawning = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
        }
    }

    void MakeThingToSpawn()
    {   
        // create a new gameObject
        GameObject clone = Instantiate(spawnPrefab, transform.position, transform.rotation) as GameObject;

        clone.GetComponent<Zoombie>().ZoombieState = ZOOMBIE_STATE.ZOOMBIE;

        // set chaseTarget if specified
        if ((chaseTarget != null) && (clone.gameObject.GetComponent<Chaser>() != null))
        {
            clone.gameObject.GetComponent<Chaser>().SetTarget(chaseTarget);
        }
    }   
}
