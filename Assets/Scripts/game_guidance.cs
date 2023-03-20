using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_guidance : MonoBehaviour
{
    // Keep this text box visible for 5 seconds
    // Then, hide it

    public GameObject textBox;
    public Text myText;

    void Start()
    {
        textBox.SetActive(true);
        Invoke("HideTextBox", 5);

        
    }

    void HideTextBox()
    {
        textBox.SetActive(false);
    }


private void OnCollisionExit2D(Collision2D collision){

    if (collision.gameObject.tag == "d1") {

        myText.text = "Hello, world!";
    }
}
    
}
