using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class message_bullet : MonoBehaviour
{
    // text object 
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Deactivate()
    {
        text.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit collision");
            // set the text to active for 5 seconds
            text.SetActive(true);
            Invoke("Deactivate", 3);
        }
    }

    // on trigger enter
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit trigger");
            // set the text to active for 5 seconds
            text.SetActive(true);
            Invoke("Deactivate", 3);



        }
    }
}
