using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C2 : MonoBehaviour
{

    Colision colision1;
    C1 colision3;

    [SerializeField]
    GameObject B1;

    [SerializeField]
    GameObject B3;

    public bool enabled = false;
    public Renderer rend;

    [SerializeField]
    private Color colorTurnTo = Color.green;

    void Awake()
    {
        colision1 = B1.GetComponent<Colision>();
        colision3 = B3.GetComponent<C1>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (colision1.enabled == false && colision3.enabled == true)
        {
            rend = GetComponent<Renderer>();
            rend.material.color = Color.green;
            enabled = true;
        }
        else
        {
            colision1.enabled = false;
            colision3.enabled = false;
            colision1.rend.material.color = Color.red;
            colision3.rend.material.color = Color.red;
        }
    }
}