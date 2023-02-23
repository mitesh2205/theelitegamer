using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPlatform : MonoBehaviour
{


    public float speed = 5f;
    public int flag = 1;
    Vector3 temp;
    public float min_length = 1f;
    public float max_length = 9f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (temp.x >= max_length)
        {
            flag = 1;
        }
        if (temp.x <= min_length)
        {
            flag = 0;
        }

        if (flag == 1)
        {
            temp = transform.localScale;
            temp.x -= 0.07f;
            transform.localScale = temp;
        }
        else
        {
            temp = transform.localScale;
            temp.x += 0.07f;
            transform.localScale = temp;
        }

    }
}
