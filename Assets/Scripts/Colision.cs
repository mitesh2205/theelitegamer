using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Colision : MonoBehaviour
{
    C1 colision1;
    C2 colision2;

    [SerializeField]
    GameObject B2;

    [SerializeField]
    GameObject B3;

    public bool enabled = false;
    public Renderer rend;

    [SerializeField]
    private Color colorTurnTo = Color.green;

    void Awake()
    {

        colision1 = B2.GetComponent<C1>();
        colision2 = B3.GetComponent<C2>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (colision1.enabled == true && colision2.enabled == true)
        {
            rend = GetComponent<Renderer>();
            rend.material.color = Color.green;
            enabled = true;
        }
        else 
        {
            colision1.enabled = false;
            colision2.enabled = false;
            colision1.rend.material.color = Color.red;
            colision2.rend.material.color = Color.red;
        }
    } 
}