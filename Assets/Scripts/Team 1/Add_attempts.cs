using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_attempts : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(Attempts_Counter.attempts < 5){
                Attempts_Counter.attempts += 1;
                Destroy(gameObject);
            }
            // SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
            // renderer.enabled = false;
        }
    }
}
