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
            Movement.resumeJetpack = false;
            Movement.resume1 = false;
            Movement.stopit = true;
            // Movement.enter_jetpack = true;
            Movement.push_force = true;
            TimeLeft.ScoreValue += 1f;
            Destroy(gameObject);
            // SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
            // renderer.enabled = false;
        }
    }
}
