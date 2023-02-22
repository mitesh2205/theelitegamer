using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Attempts_Counter : MonoBehaviour
{
    Text showAttempts;
    public static int attempts = 3;
    // Start is called before the first frame update
    void Start()
    {
        showAttempts = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        showAttempts.text = "Attempts left: " + attempts;
    }
}
