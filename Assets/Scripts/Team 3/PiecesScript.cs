using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesScript : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool IsRightPosition;
    public bool Selected;
    float destroyDelay = 2f;
    public float leftXCoordinate = 372.0f;
    public float rightXCoordinate = 388f;
    public float topYCoordinate = -1.2f;
    public float bottomYCoordinate = -3.0f;

    void Start()
    {
        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(leftXCoordinate, rightXCoordinate), Random.Range(topYCoordinate, bottomYCoordinate));
        
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("bullet")){
            if (Vector3.Distance(transform.position, RightPosition) != 0.0f){
            transform.position = RightPosition;
            FinishPuzzleScript.totalPieces -=1;
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
