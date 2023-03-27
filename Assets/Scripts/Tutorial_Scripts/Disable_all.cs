using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable_all : MonoBehaviour
{
    public GameObject jetpack;
    public GameObject green_blue;
    public GameObject spring;
    public GameObject ladder;
    public GameObject rope;
    public GameObject reuse_jetpack;
    public GameObject starting;

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
            jetpack.SetActive(false);
            green_blue.SetActive(false);
            spring.SetActive(false);
            ladder.SetActive(false);
            rope.SetActive(false);
            reuse_jetpack.SetActive(false);
            starting.SetActive(true);
        }
    }
}
