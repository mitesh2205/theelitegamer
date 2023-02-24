using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_time : MonoBehaviour
{
    // onTriggerEnter2D will be called when player collides with the object and will add 10 seconds to the timer

    public LevelTimerScript levelTimer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            levelTimer.timer += 10;
            //Destroy(gameObject);
            SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
            renderer.enabled = false;
        }
    }
}
