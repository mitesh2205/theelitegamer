using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step_on_blue : MonoBehaviour
{
    public GameObject step_on_blue;
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
            step_on_blue.SetActive(true);
        }
    }
}
