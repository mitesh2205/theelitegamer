using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{ 
    private Transform destination;
    public bool isPortal1;
    public float distance = 0.2f;


    Colision colision;
    C1 colision1;
    C2 colision2;

    [SerializeField] 
    GameObject B1;

    [SerializeField]
    GameObject B2;

    [SerializeField]
    GameObject B3;

    //private Renderer rend;

    [SerializeField]
    private Color colorTurnTo = Color.green;

    void Awake()
    {
        colision = B1.GetComponent<Colision>();
        colision1 = B2.GetComponent<C1>();
        colision2 = B3.GetComponent<C2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        if(isPortal1==false)
        {
            destination = GameObject.FindGameObjectWithTag("Portal1").GetComponent<Transform>();
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("Portal2").GetComponent<Transform>();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (colision.enabled == true && colision1.enabled==true && colision2.enabled==true)
        {
            if (Vector2.Distance(transform.position, other.transform.position) > distance)
            {
                other.transform.position = new Vector2(destination.position.x, destination.position.y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (colision.enabled == true && colision1.enabled == true && colision2.enabled == true)
        {
            //rend = GetComponent<Renderer>();
            //rend.material.color = Color.green;
        }
    }
}
