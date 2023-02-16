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

}
