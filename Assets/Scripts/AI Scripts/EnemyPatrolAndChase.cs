using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyPatrolAndChase : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;
    public float radarDistance = 5f;
    public float maxChaseSpeed = 15f;

    private int currentWaypoint = 0;
    private bool isChasing = false;
    public Transform chaseTarget;
    private AIPath aiPath;

    // Start is called before the first frame update
    void Start()
    {

        aiPath = GetComponent<AIPath>();
        aiPath.destination = waypoints[currentWaypoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing)
        {
            Chase();
        }
        else
        {
            // Patrol between waypoints
            Patrol();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log(collider.tag + " has entered the trigger");
            // Start chasing the player
            isChasing = true;
            chaseTarget = collider.transform;
            Debug.Log(chaseTarget);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasing = false;
            chaseTarget = null;
            aiPath.destination = waypoints[0].position;
        }
    }

    private void Patrol(){
        if (Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position) < 0.1f)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
            //  flip the sprite if the enemy touches the waypoint and moves to the next waypoint
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                
        }
        // transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, speed * Time.deltaTime);
        aiPath.destination = waypoints[currentWaypoint].position;
        Debug.Log("Setting destination to: " + aiPath.destination); 
    }

    private void Chase(){
        // Chase the target
        float distanceToPlayer = Vector2.Distance(transform.position, chaseTarget.position);

        // Calculate the chase speed based on the distance
        float chaseSpeed = Mathf.Lerp(0, maxChaseSpeed, distanceToPlayer / radarDistance);

        // Set the speed of the enemy
        aiPath.maxSpeed = chaseSpeed;

        aiPath.destination = chaseTarget.transform.position;

        // Check if the target is out of radar range
        // if (Vector2.Distance(transform.position, chaseTarget.position) > radarDistance * 1.2f)
        // {
        //     // Stop chasing the target
        //     isChasing = false;
        //     aiPath.destination = waypoints[currentWaypoint].position;
        // }
    }

}
