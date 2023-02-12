using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ProjectilePoint;
    public GameObject porjectilePrefab;
    private Rigidbody _rb;
    private Vector3 _velocity;
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
        _velocity = new Vector3(10f, 10f, 0f);
            
    }

    void OnCollisionEnter(Collision collision){
        ReflectProjectile(_rb, collision.contacts[0].normal);
    }
    
    private void ReflectProjectile(Rigidbody rb, Vector3 reflectVector)
    {    
        _velocity = Vector3.Reflect(_velocity, reflectVector);
        _rb.velocity = _velocity;
        Debug.Log("velocity ");
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
