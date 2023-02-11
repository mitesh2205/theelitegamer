using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ProjectilePoint;
    public GameObject porjectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }
    void Shoot(){
        Instantiate(porjectilePrefab, ProjectilePoint.position, ProjectilePoint.rotation);
    }
}
