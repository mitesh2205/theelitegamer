using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public Text timerText;

    public static bool issafe;

    public float countdownTime;
    private float timeleft;
    private bool resetCounter = false;
    public Text countdownText;
    void Start()
    {
        timerSlider.maxValue = countdownTime;
        timerSlider.value = countdownTime;
        timeleft = countdownTime;
        issafe = false;
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeleft / 60);
        int seconds = Mathf.FloorToInt(timeleft - minutes * 60);
        string texttime = string.Format("{0:00}:{1:00}", minutes, seconds);
        countdownText.text = texttime;
        timerSlider.value = timeleft;
        if (timeleft <= 0)
        {
            timeleft = countdownTime;
            resetCounter = !resetCounter;
            if (resetCounter)
            {
                timerSlider.maxValue = countdownTime;
                timerSlider.value = countdownTime;
                Image fill = timerSlider.fillRect.GetComponent<Image>();
                fill.color = Color.blue;
                issafe = true;
            }
            else
            {
                timerSlider.maxValue = countdownTime;
                timerSlider.value = countdownTime;
                Image fill = timerSlider.fillRect.GetComponent<Image>();
                fill.color = Color.red;
                issafe = false;
            }
        }


    }
    public static bool IsBlueFloorSafe()
    {
        return issafe;
    }
    public static bool IsRedFloorSafe()
    {
        return !issafe;
    }

}
