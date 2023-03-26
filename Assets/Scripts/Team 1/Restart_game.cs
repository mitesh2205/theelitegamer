using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_game : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }


    public void Start_game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Tutorial_level()
    {
        SceneManager.LoadScene(1);
    }

    public void level_1()
    {
        SceneManager.LoadScene(2);
    }

    public void level_2()
    {
        SceneManager.LoadScene(3);
    }

    public void level_3()
    {
        SceneManager.LoadScene(4);
    }

    public void level_4()
    {
        SceneManager.LoadScene(5);
    }

}
