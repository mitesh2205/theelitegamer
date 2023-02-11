using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesScript : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool IsRightPosition;
    public bool Selected;
    float destroyDelay = 2f;
    void Start()
    {
        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(230f, 252f), Random.Range(4f, -7f));
        
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("bullet")){
            if (Vector3.Distance(transform.position, RightPosition) != 0.0f){
            transform.position = RightPosition;
            Destroy(collision.gameObject, destroyDelay);
            
        }
            
        }
    }

    void Update()
    {
        // if(Vector3.Distance(transform.position, RightPosition) < 0.2f){
        //     if(!Selected){
        //         transform.position = RightPosition;
        //         IsRightPosition = true;
        //         Debug.Log("we did it");

        //     }
        // }
        
    }
}
