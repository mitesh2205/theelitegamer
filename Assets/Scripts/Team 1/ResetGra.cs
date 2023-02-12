using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGra : MonoBehaviour
{
    private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has entered the gravity zone");
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1;
        }
    }
}
