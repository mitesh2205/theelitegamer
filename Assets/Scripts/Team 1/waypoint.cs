using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypoint = 0;

    public float speed = 2.0f;
    public bool flipplayer = true;

    // Update is called once per frame
    void Update()
    {
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
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, speed * Time.deltaTime);

    }
}
