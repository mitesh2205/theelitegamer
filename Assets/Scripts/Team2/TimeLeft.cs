using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLeft : MonoBehaviour
{
    public static float ScoreValue = Movement.jetpackDuration;
    Text score;
    Text jetpack;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        score.text = "(j):" + ScoreValue.ToString("N2");

        if (ScoreValue <= 0)
        {
            Debug.Log("Time is up");
            score.text = "(j): 0";
            ScoreValue = Movement.jetpackDuration;
        }
        else
        {
            Debug.Log("Time is not up");
            score.text = "(j):" + ScoreValue.ToString("N2");
        }
    }
}


