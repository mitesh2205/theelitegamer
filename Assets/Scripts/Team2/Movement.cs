using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float jetpackDuration = 2f;  // Duration of the jetpack in seconds
    public float jetpackForce = 10f;    // Force applied by the jetpack
    private float elapsedTime = 0f;      // Time elapsed since the jetpack was activated
    private Rigidbody2D rigidbody;      // Reference to the Rigidbody2D component
    private bool isJetpacking = false;   // Flag to check if the jetpack is active
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !isJetpacking && isGrounded)
        {
            elapsedTime = 0f;
            isJetpacking = true;
        }

        if (isJetpacking)
        {
            isGrounded = false;
            elapsedTime += Time.deltaTime;
            TimeLeft.ScoreValue = jetpackDuration - elapsedTime;
            rigidbody.velocity = Vector2.up * jetpackForce;

            if (elapsedTime >= jetpackDuration)
            {
                isJetpacking = false;
            }
        }
        else if(gameObject.CompareTag("Ground"))
        {
            TimeLeft.ScoreValue = 2;
            isGrounded = true;
        }

        }
    }








