using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMonsterDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected " + collision.gameObject.tag);
        if (collision.gameObject.tag == "bullet")
        {
            Debug.Log("enemy is dead");
            Destroy(collision.gameObject);
            Destroy(transform.parent.gameObject);
        }
    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     Debug.Log("Trigger detected " + collision.gameObject.tag);
    //     if (collision.gameObject.tag == "bullet")
    //     {
    //         Debug.Log("enemy is dead");
    //         Destroy(collision.gameObject);
    //         Destroy(transform.parent.gameObject);
    //     }
    // }
}
