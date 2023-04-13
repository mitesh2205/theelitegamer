using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class play_pause_toggle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Sprite playImage;
    public Sprite pauseImage;
    // public GameObject pauseButton;
    // public GameObject playButton;
    void Start()
    {
        
        // get array of all sprites
        GetComponent<Image>().sprite = playImage;
    }

    // Update is called once per frame
    void Update()
    {
        if(Restart_game.isPaused){
            GetComponent<Image>().sprite = playImage;
            // change size of image
        }
        else{
            GetComponent<Image>().sprite = pauseImage;
        }
    }
}
