using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_guidance : MonoBehaviour
{
    // Keep this text box visible for 5 seconds
    // Then, hide it

    public GameObject textBox;

    void Start()
    {
        textBox.SetActive(true);
        Invoke("HideTextBox", 5);
    }

    void HideTextBox()
    {
        textBox.SetActive(false);
    }
}
