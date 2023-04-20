using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Attempts_Counter : MonoBehaviour
{
    Text showAttempts;
    private Animator anim;


    public static int attempts = 5;
    // Start is called before the first frame update
    void Start()
    {
        showAttempts = GetComponent<Text>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //  switch case for attempts
        Debug.Log("Attempts: " + attempts);
        switch (attempts)
        {
            case 5:
                anim.SetInteger("health_status", 5);
                break;
            case 4:
                anim.SetInteger("health_status", 4);
                break;
            case 3:
                anim.SetInteger("health_status", 3);
                break;
            case 2:
                anim.SetInteger("health_status", 2);
                break;
            case 1:
                anim.SetInteger("health_status", 1);
                break;
            case 0:
                anim.SetInteger("health_status", 0);
                break;
            default:    
                anim.SetInteger("health_status", 5);
                break;
           
        }
    }
}
