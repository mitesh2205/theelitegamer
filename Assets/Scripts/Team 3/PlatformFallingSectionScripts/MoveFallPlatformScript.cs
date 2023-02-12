using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFallPlatformScript : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;
    float fallDelay = 1f;
    float destroyDelay = 1f;
    [SerializeField]  Rigidbody2D rb;

    private bool isBulletHit = false;


    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }

        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }

        if (!isBulletHit)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed*Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("bullet")){
            Debug.Log("Collision detected");
            isBulletHit = true;
            StartCoroutine(Fall());
            rb.bodyType = RigidbodyType2D.Dynamic;
            Debug.Log(rb.constraints);
            Destroy(collision.gameObject, destroyDelay);
        }
        
    }
    private IEnumerator Fall(){
        yield return new WaitForSeconds(fallDelay);
    }
}
