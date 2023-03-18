using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static float jetpackDuration = 1.5f;  // Duration of the jetpack in seconds
    public static float jetpackForce = 10f;    // Force applied by the jetpack
    public static float elapsedTime = 0f;      // Time elapsed since the jetpack was activated
    public Rigidbody2D rigidbody;      // Reference to the Rigidbody2D component
    public static bool isJetpacking = false;   // Flag to check if the jetpack is active
    public static bool isGrounded = true;

    // public static bool enter_jetpack = true;
    public static bool push_force = true;
    public static bool usedJetpack = false;
    public static bool resumeJetpack = false;

    public static bool resume1 = false;

    public static bool stopit = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        TimeLeft.ScoreValue = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // print("update is calling");
        // print(isJetpacking);
        // print("isjjet");
        // print(isGrounded);
        // print("isgrpound");
        if (Input.GetKeyDown(KeyCode.J) && resumeJetpack)
        {
            print("j key pressed");
            resumeJetpack = false;
            stopit = false;
            isJetpacking = false;
            //wait for 2 seconds
            resume1 = true;

        }
        else if (Input.GetKeyDown(KeyCode.J) && !resumeJetpack)
        {
            print("j key pressed again");
            stopit = true;
            isGrounded = true;
            print("j key isGrounded:" + isGrounded);
            print("j key isJetpacking:" + isJetpacking);
            print("j key stopit:" + stopit);
        }
        // if (Input.GetKeyDown(KeyCode.J) && resume1)
        // {
        //     print("j key pressed again");
        //     stopit = true;
        //     isGrounded = true;
        //     print("j key isGrounded:" + isGrounded);
        //     print("j key isJetpacking:" + isJetpacking);
        //     print("j key stopit:" + stopit);
        // }
        if (Input.GetKeyDown(KeyCode.J) && !isJetpacking && isGrounded && stopit)
        {
            print("j key");
            print("isGrounded:" + isGrounded);
            // elapsedTime = 0f;
            isJetpacking = true;
            resumeJetpack = true;
        }

        if (isJetpacking)
        {
            print("j key inside isjetpacking");
            print("is jetpacking" + isJetpacking);
            print("push force:" + push_force);
            isGrounded = false;
            elapsedTime += Time.deltaTime;
            TimeLeft.ScoreValue = jetpackDuration - elapsedTime;
            if (elapsedTime > (jetpackDuration))
            {
                print("elapsedTime:" + elapsedTime);
                print("jetpackDuration:" + jetpackDuration);
                isJetpacking = false;
                isGrounded = true;
                TimeLeft.ScoreValue = 0f;
                jetpackDuration = 0f;
                usedJetpack = true;
                push_force = false;
                elapsedTime = 0f;
            }
            // print("fff");
            if (push_force)
            {
                print("push_force");
                rigidbody.velocity = Vector2.up * jetpackForce;
                print("TimeLeft.ScoreValue");
            }
            // rigidbody.velocity = Vector2.up * jetpackForce;
            // print("TimeLeft.ScoreValue");


        }
        if (gameObject.CompareTag("Ground"))
        {
            // TimeLeft.ScoreValue = 2.0f;
            print("ground");
            isGrounded = true;
        }

    }
}
