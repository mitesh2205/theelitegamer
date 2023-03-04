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

        if (Input.GetKeyDown(KeyCode.J) && !isJetpacking && isGrounded)
        {
            print("j key");
            elapsedTime = 0f;
            isJetpacking = true;
        }

        if (isJetpacking)
        {
            print("is jetpacking" + isJetpacking);
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
