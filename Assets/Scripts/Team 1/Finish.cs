using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Finish : MonoBehaviour
{
    private bool levelComplete = false;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player" && !levelComplete)
        {
            levelComplete = true;
            // finish.Play();
            // Invoke("completeLevel", 2f);
            
            

        }
    }

    private void completeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  // Load next scene
    }

    
}
