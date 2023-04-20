using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
// using player script
public class LevelTimerScript : MonoBehaviour
{
    public float timer;
    public float initialTimerValue;
    public GameObject RestartLevel;
    public static bool timerover = false;
    public LevelOverScreenScript LevelOverScreenScript;
    public static event Action onTimerOver;
    private TMPro.TextMeshProUGUI timerText;
    private bool Switch = false;
    private float timerFlashTime;
    private float timerFlashTime2;
    // Start is called before the first frame update
    void Start()
    {
        initialTimerValue = timer;
        timerText = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // flash timer when it's near 30 seconds
        if (timer <= 30)
        {
            timerFlashTime += Time.deltaTime;
            timerFlashTime2 += Time.deltaTime;
            if (timerFlashTime<=0.5f)
            {
                timerText.color = Color.red;
                // Switch = true;
            }
            else if(timerFlashTime2<=1f)
            {
                timerText.color = Color.yellow;
                // Switch = false;
            }
            else{
                timerFlashTime = 0;
                timerFlashTime2 = 0;
            }
            // timerText.color = Color.red;
        }
        else
        {
            timerText.color = Color.yellow;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            //timerText.text = "Time Left: " + Mathf.Round(timer);
            timerText.text = "" + Mathf.Round(timer);
        }
        if (timer <= 0)
        {
            // timer = initialTimerValue;
            GameOver();
        }
    }

    public void resetTimer()
    {
        timer = initialTimerValue;
    }

    public void GameOver()
    {
        // RestartLevel.SetActive(true);
        timerover = true;
    }
}
