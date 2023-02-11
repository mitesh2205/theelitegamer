using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade_v1 : MonoBehaviour
{

    public Transform pos1_v1;
    public Transform pos2_v1;
    public float speed1;
    bool turnback1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= pos1_v1.position.y)
        {
            turnback1 = true;
        }
        if(transform.position.y >= pos2_v1.position.y)     
        {
            turnback1 = false;
        }
        if(turnback1)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos2_v1.position, speed1 * Time.deltaTime);

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pos1_v1.position, speed1 * Time.deltaTime);

        }

        
        
    }
}
