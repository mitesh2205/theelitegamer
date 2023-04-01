using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.Transform;
using UnityEngine.SceneManagement;

public class jetpack_animation_controller : MonoBehaviour
{
    public Animator jetPackAnimator;
    private SpriteRenderer jetpackSprite;
    // private Transform jetpack;
    // Start is called before the first frame update
    void Start()
    {
        jetPackAnimator = GetComponent<Animator>();
        jetpackSprite = GetComponent<SpriteRenderer>();
        // jetpack = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.spriteFlip){
            Debug.Log("Flipping");
            jetpackSprite.flipX = false;
            // jetpack.transform.position = new Vector3(-0.72f, -1.4f, 0);
            // jetpack.position.x = -0.72f;
            // jetpack.position.y = -1.4f;
            
        } else {
            Debug.Log("Not Flipping");
            jetpackSprite.flipX = true;
            // jetpack.transform.position = new Vector3(0.51f, -1.4f, 0);
            // jetpack.position.x = 0.51f;
            // jetpack.position.y = -1.4f;
        }
        if(Movement.isJetpacking){
            jetPackAnimator.SetBool("jetpack_status", true);
        } else {
            jetPackAnimator.SetBool("jetpack_status", false);
        }
    }
}
