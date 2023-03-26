using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spring_animation_controller : MonoBehaviour
{
    public Animator animator;
    public bool spring_active = false;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has collided with spring");
            spring_active = true;
            animator.SetBool("spring_active", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has exited spring");
            spring_active = false;
            animator.SetBool("spring_active", false);
        }
    }
}
