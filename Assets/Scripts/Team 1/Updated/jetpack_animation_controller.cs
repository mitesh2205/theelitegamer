using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jetpack_animation_controller : MonoBehaviour
{
    public Animator jetPackAnimator;
    // Start is called before the first frame update
    void Start()
    {
        jetPackAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Movement.isJetpacking){
            jetPackAnimator.SetBool("jetpack_status", true);
        } else {
            jetPackAnimator.SetBool("jetpack_status", false);
        }
    }
}
