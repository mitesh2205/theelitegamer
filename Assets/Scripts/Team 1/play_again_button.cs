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
        sendData = false;
        play_again_panel_button.SetActive(false);
    }
    public void no()
    {
        sendData = true;
        // load scene based on index number: 0 = main menu, 1 = level 1, 2 = level 2, etc.
        SceneManager.LoadScene(0);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;

    }
}
