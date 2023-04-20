using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play_again_button : MonoBehaviour
{
    public static bool sendData = false;
    public GameObject play_again_panel_button;
    // Start is called before the first frame update
    public void yes()
    {
        Time.timeScale = 1f;
        Movement.push_force = true;
        Movement.jetpackDuration = 1.5f;
        sendData = false;
        play_again_panel_button.SetActive(false);
    }
    public void no()
    {
        sendData = true;
        Movement.push_force = true;
        Movement.jetpackDuration = 1.5f;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene(0);

        Time.timeScale = 1f;

    }
}
