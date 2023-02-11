using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jetpack : MonoBehaviour
{

    public bool up = false;
    public bool down = false;

    public float jetSpeed;
    public float jetFill;

    private Rigidbody2D rb;

    public Vector3 DirectionUp = Vector3.up;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jetSpeed = 100f;
        jetFill = 5f;

        up = false;
        down  = false;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(up == true)
        {
            rb.AddForce(DirectionUp * jetSpeed * Time.deltaTime);
            jetFill -= Time.deltaTime;
        }

        if(down == true)
        {
            jetFill += Time.deltaTime;
        }

        if(jetFill >= 5)
        {
            jetFill = 5f;
        }

        if(jetFill <= 0)
        {
            jetSpeed = -100f;
        }

        
        
    }

    public void ButtonPress()
    {
        up = true;
        down = false;

    }

    public void ButtonUnPress()
    {
        up = false;
        down = true;

    }
}
