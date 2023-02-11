using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeLeft : MonoBehaviour
{

public static float ScoreValue = 2.0f;
Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Fuel left in jetpack: " + ScoreValue;
    }
}
