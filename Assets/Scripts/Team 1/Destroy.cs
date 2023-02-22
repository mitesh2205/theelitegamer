using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    public float timeTillDestroy;

    // Update is called once per frame
    private void Update()
    {
        Destroy(gameObject, timeTillDestroy);
    }
}