using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green_blue_on : MonoBehaviour
{
    public GameObject green_blue;
    private void Awake()
    {
        green_blue.SetActive(false);
    }
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
            green_blue.SetActive(true);
        }
    }
}
