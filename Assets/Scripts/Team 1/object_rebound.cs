using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_rebound : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        Vector2 normal = contact.normal;
        Vector2 velocity = rigidBody2D.velocity;

        rigidBody2D.velocity = Vector2.Reflect(velocity, normal);
    }
}
