using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDestroyPlatform : MonoBehaviour
{
    [SerializeField]  Rigidbody2D rb;
    [SerializeField] float RestoreDelay = 2f;
     [SerializeField] float fallDelay = 2f;
    [SerializeField]  float destroyDelay = 2f;

    private Vector3 startPosition;

    void Start(){
        startPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        
        if (collision.gameObject.CompareTag("Player"))
        {
            
            StartCoroutine(Fall());
        
            
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Debug.Log("1");
        StartCoroutine(RestorePlatform());
        Destroy(gameObject, destroyDelay);
    }

    private IEnumerator RestorePlatform()
    {
        transform.position = startPosition;
        Debug.Log("2");
         yield return new WaitForSeconds(RestoreDelay);
    }
}


