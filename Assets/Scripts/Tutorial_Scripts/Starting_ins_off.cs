using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting_ins_off : MonoBehaviour
{
    public GameObject starting_ins;
    private void Awake()
    {
        starting_ins.SetActive(false);
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
            starting_ins.SetActive(false);
        }
    }
}
