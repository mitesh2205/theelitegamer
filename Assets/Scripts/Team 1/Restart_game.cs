using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_game : MonoBehaviour
{
    public static bool isPaused = false;
    public void Restart()
    {
        SceneManager.LoadScene(0);
        Attempts_Counter.attempts=5;
        increment_death d;
        d = FindObjectOfType<increment_death>();
        Time.timeScale = 1;
        d.ResetDeath();
        isPaused = false;
        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // increment_death.ResetDeath();
        Attempts_Counter.attempts=5;
        increment_death d;
        d = FindObjectOfType<increment_death>();
        d.ResetDeath();
        Time.timeScale = 1;
        isPaused = false;
        // Attempts_Counter.attemps=5;
    }

    public void Start_game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Tutorial_level()
    {
        SceneManager.LoadScene(1);
    }
    public void Tutorial_level_Reward()
    {
        SceneManager.LoadScene(2);
    }

    public void level_1()
    {
        SceneManager.LoadScene(3);
    }

    public void level_2()
    {
        SceneManager.LoadScene(4);
    }

    public void level_3()
    {
        SceneManager.LoadScene(5);
    }

    public void level_4()
    {
        SceneManager.LoadScene(6);
    }
    public void level_5()
    {
        SceneManager.LoadScene(7);
    }

    public void level_6()
    {
        SceneManager.LoadScene(8);
    }

    public void level_7()
    {
        SceneManager.LoadScene(9);
    }

    public void level_8()
    {
        SceneManager.LoadScene(10);
    }

    public void level_9()
    {
        SceneManager.LoadScene(11);
    }

    public static void PauseGame()
    {
        // check if game is already paused
        if (Time.timeScale == 0)
        {
            // if game is paused, then unpause it
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            // if game is not paused, then pause it
            Time.timeScale = 0;
            isPaused = true;
        }
    }


}
