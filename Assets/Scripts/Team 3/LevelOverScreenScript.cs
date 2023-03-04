using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LevelOverScreenScript : MonoBehaviour
{
    public Button RestartButton;
    public static bool isGameOver = false;
    void Start()
    {
        Button btn = RestartButton.GetComponent<Button>();
        btn.onClick.AddListener(RestartLevel);
    }

    void RestartLevel()
    {
        isGameOver = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
