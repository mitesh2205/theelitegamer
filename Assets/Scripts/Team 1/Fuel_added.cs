using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel_added : MonoBehaviour
{
    // onTriggerEnter2D will be called when player collides with the object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Movement.jetpackDuration += 1f;
            TimeLeft.ScoreValue += 1f;
            Destroy(gameObject);
        }
    }
}
