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
            // print("fff");
            print("is jetpacking");
            isGrounded = false;
            elapsedTime += Time.deltaTime;
            TimeLeft.ScoreValue = jetpackDuration - elapsedTime;
            rigidbody.velocity = Vector2.up * jetpackForce;

            if (elapsedTime >= jetpackDuration)
            {
                isJetpacking = false;
                isGrounded = true;
                TimeLeft.ScoreValue = 0f;
                jetpackDuration = 0f;
            }
        }
        if (gameObject.CompareTag("Ground"))
        {
            // TimeLeft.ScoreValue = 2.0f;
            print("ground");
            isGrounded = true;
        }
    }
}
