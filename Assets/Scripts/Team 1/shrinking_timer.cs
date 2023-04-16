using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shrinking_timer : MonoBehaviour
{
    // public float ShrinkDuration = 3f;

    // public LevelTimerScript LevelTimerScript;
    // // The target scale
    // public Vector3 TargetScale = Vector3.one * 1.5f;

    // public GameObject timer;
    // private bool statShrink = true;
    // // The starting scale
    // Vector3 startScale = new Vector3(1.08f, 1.65f, 1f);
    
    // // T is our interpolant for our linear interpolation.
    // float t = 0;
    
    void OnEnable() {
        // initialize stuff in OnEnable
        
    }
    // Start is called before the first frame update
    void Start()
    {
        // startScale = transform.localScale;
        // timer = GameObject.Find("time_object");
        // t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // if(LevelTimerScript.timer<=30f && statShrink){
        //     Debug.Log("Shrinking");
        //     StartCoroutine(ShrinkTimer());
        // }
        // else if(LevelTimerScript.timer>30f){
        //     // Debug.Log("Not Shrinking");
        //     transform.localScale = startScale;
        //     // statShrink = true;
        // }

    }

    // IEnumerator ShrinkTimer() {
    //     // Reset our interpolant
    //     t = 0;
    //     statShrink = false;
    //     // While our interpolant is less than 1
    //     while (t < 1) {
    //         // Increment our interpolant
    //         t += Time.deltaTime / ShrinkDuration;
    //         // Lerp between the start and target scale
    //         transform.localScale = Vector3.Lerp(startScale, TargetScale, t);
    //         // Wait for the next frame
    //         yield return new WaitForSeconds(2f);
    //         transform.localScale = Vector3.Lerp(TargetScale, startScale, t);
    //     }
    //     statShrink = true;
    // }
}
