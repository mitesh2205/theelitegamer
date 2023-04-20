using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reuse_jetpacj_off : MonoBehaviour
{
    public GameObject jetpack;
    private void Awake()
    {
        jetpack.SetActive(false);
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
            jetpack.SetActive(false);
        }
    }
}
