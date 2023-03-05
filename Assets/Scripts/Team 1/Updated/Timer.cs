using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public Text timerText;

    // public static bool issafe;

    public float countdownTime;
    public static float timeleft;
    public static bool resetCounter = false;
    public Text countdownText;
    public static bool blue_safe = false;
    public static bool green_safe = true;
    public static bool danger_time = true;
    Color blueColor = new Color();

    void Start()
    {
        timerSlider.maxValue = countdownTime;
        timerSlider.value = countdownTime;
        timeleft = countdownTime;
        // issafe = false;
    }

    void Update()
    {
        if(Player.reset_level_timer){
            timeleft = 0f;
            Player.reset_level_timer = false;
            danger_time = true;
            resetCounter = true;
        }
        if (danger_time)
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
                    // Color blue = "#0088F3".ToColor();
                    ColorUtility.TryParseHtmlString("#0088F3", out blueColor);
                    fill.color = blueColor;
                    // issafe = true;
                    blue_safe = true;
                    green_safe = false;

                }
                else
                {
                    timerSlider.maxValue = countdownTime;
                    timerSlider.value = countdownTime;
                    Image fill = timerSlider.fillRect.GetComponent<Image>();
                    fill.color = Color.green;
                    // issafe = false;
                    green_safe = true;
                    blue_safe = false;

                }
            }
        }
        else
        {

            green_safe = true;
            blue_safe = true;
        }
        // timeleft -= Time.deltaTime;
        // int minutes = Mathf.FloorToInt(timeleft / 60);
        // int seconds = Mathf.FloorToInt(timeleft - minutes * 60);
        // string texttime = string.Format("{0:00}:{1:00}", minutes, seconds);
        // countdownText.text = texttime;
        // timerSlider.value = timeleft;
        // if (timeleft <= 0)
        // {
        //     timeleft = countdownTime;
        //     resetCounter = !resetCounter;
        //     if (resetCounter)
        //     {
        //         timerSlider.maxValue = countdownTime;
        //         timerSlider.value = countdownTime;
        //         Image fill = timerSlider.fillRect.GetComponent<Image>();
        //         fill.color = Color.blue;
        //         issafe = true;
        //     }
        //     else
        //     {
        //         timerSlider.maxValue = countdownTime;
        //         timerSlider.value = countdownTime;
        //         Image fill = timerSlider.fillRect.GetComponent<Image>();
        //         fill.color = Color.green;
        //         issafe = false;
        //     }
        // }


    }
    public static bool IsBlueFloorSafe()
    {
        // return issafe;
        return blue_safe;
    }
    public static bool IsGreenFloorSafe()
    {
        // return !issafe;
        return green_safe;
    }

}
