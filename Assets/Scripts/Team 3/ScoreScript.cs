using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreVal = 20;
    TMPro.TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
     score = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Bullets : "+ scoreVal.ToString();
    }
}
