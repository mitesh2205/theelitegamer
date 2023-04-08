using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingAndFallingPlatforms : MonoBehaviour
{
    private Animator animator;
    private bool isFalling = false;
    private float fallingTimer = 0f;
    private float reappearingTimer = 0f;

    public GameObject platformPrefab;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isFalling = true;
        }
    }

    private void Update()
    {
        if (isFalling)
        {
            fallingTimer += Time.deltaTime;

            if (fallingTimer >= 3f)
            {
                isFalling = false;
                Destroy(gameObject, 1f);
            }
        }
        
    }

}
