using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blades : MonoBehaviour
{

    public Transform pos1;
    public Transform pos2;
    public float speed;
    bool turnback;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= pos1.position.y)
        {
            turnback = true;
        }
        if(transform.position.y <= pos2.position.y)     
        {
            turnback = false;
        }
        if(turnback)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos2.position, speed * Time.deltaTime);

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pos1.position, speed * Time.deltaTime);

        }

        
        
    }
}
