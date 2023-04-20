using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step_on_green_disable : MonoBehaviour
{
    public GameObject step_on_green;

    public GameObject step_on_blue;

    public GameObject congo_reward;
    // Start is called before the first frame update
    void Start()
    {
        step_on_green.SetActive(false);
        step_on_blue.SetActive(false);
        congo_reward.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            step_on_green.SetActive(false);
            step_on_blue.SetActive(false);
            congo_reward.SetActive(false);
        }
    }
}
