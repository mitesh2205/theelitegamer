using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_trigger : MonoBehaviour
{
    // get the sprite renderer
    public SpriteRenderer spriteRenderer;
    public static bool checkpointReached = false;

    // make the public variable to save the checkpoint position when player reaches the checkpoint
    public static Vector3 checkpointPosition;
    public LevelTimerScript levelTimer;
    // make a public variable to save the time left when player reaches the checkpoint
    public static float timeLeft;

    // make a public variable to save the jet pack left when player reaches the checkpoint
    public static float jetPackLeft;
    public static float timer_jetpack;

    public static float jetpackduration1;

    public bool firstTime = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (firstTime)
            {
                // set the color of sprite renderer to green when player enters the trigger
                spriteRenderer.color = Color.green;
                // checkpointReached = true;
                // // set the checkpoint position to the current position of the player with some offset on right side 
                // checkpointPosition = new Vector3(collision.transform.position.x + 8, collision.transform.position.y, collision.transform.position.z);
                // // set the time left to the current time left
                // timeLeft = levelTimer.timer;
                // // set the jet pack left to the current jet pack left
                // jetPackLeft = Movement.elapsedTime;
                // timer_jetpack = TimeLeft.ScoreValue;
                // jetpackduration1 = Movement.jetpackDuration;
                // Debug.Log("b_checkpoint:" + checkpointPosition);
                // Debug.Log("b_elapsedTime:" + Movement.elapsedTime);
                // Debug.Log("b_pushflag:" + Movement.push_force);
                firstTime = false;
            }


        }



    }
}
