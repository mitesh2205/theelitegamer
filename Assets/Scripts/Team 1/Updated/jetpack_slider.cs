using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class jetpack_slider : MonoBehaviour
{
    public Slider jetpackSlider;
    public float jetpackMaxUseTime = 3f;
    public static float jetpackFuelLeft = 1.5f;
    // public static bool resetJetpackCounter = false;
    
    // Start is called before the first frame update
    void Start()
    {
        jetpackSlider.maxValue = jetpackMaxUseTime;
        jetpackSlider.value = Movement.jetpackDuration;
        jetpackFuelLeft = Movement.jetpackDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if(Movement.isJetpacking){
            jetpackSlider.value = TimeLeft.ScoreValue;
            Debug.Log("jetpackSlider.value: " + jetpackSlider.value);
            // jetpackSlider.value -= Time.deltaTime;
            // jetpackFuelLeft -= Time.deltaTime;
            jetpackFuelLeft = Movement.jetpackDuration;
        }
        else{
            // jetpackSlider.value = Movement.jetpackDuration;
            jetpackSlider.value = TimeLeft.ScoreValue;
        }
        if(Player.reset_level_timer){
            jetpackSlider.value = TimeLeft.ScoreValue;
            jetpackFuelLeft = TimeLeft.ScoreValue;
            // resetJetpackCounter = false;
        }
    }
}
