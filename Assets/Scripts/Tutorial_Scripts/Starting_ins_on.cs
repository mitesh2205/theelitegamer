using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting_ins_on : MonoBehaviour
{
    public GameObject starting_ins;

    private void Awake()
    {
        starting_ins.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        starting_ins.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
