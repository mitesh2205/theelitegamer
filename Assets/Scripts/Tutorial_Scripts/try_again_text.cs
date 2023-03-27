using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class try_again_text : MonoBehaviour
{
    public GameObject try_again;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (Count_1.successfully == false)
            {

                try_again.SetActive(true);
            }
            else
            {
                try_again.SetActive(false);
            }
        }
    }
}
