using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder_on : MonoBehaviour
{
    public GameObject ladder;
    public GameObject jetpack;
    public GameObject starting_ins;

    private void Awake()
    {
        ladder.SetActive(false);
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
            ladder.SetActive(true);
            jetpack.SetActive(false);
            starting_ins.SetActive(false);
        }
    }
}
