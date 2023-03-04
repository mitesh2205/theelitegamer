using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float timeTillSpawn;
    public float startTimeTillSpawn;

    public GameObject laser;
    public Transform whereToSpawn;

    private void Update()
    {
        if(timeTillSpawn<=0)
        {
            Instantiate(laser, whereToSpawn.position, whereToSpawn.rotation);

            timeTillSpawn = startTimeTillSpawn;
        }
        else
        {
            timeTillSpawn -= Time.deltaTime;
        }
    } 
}