using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_trigger : MonoBehaviour
{
     public GameObject invisible_platform;
     public GameObject activate_platform;
     public GameObject activate_spring;
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //  set attruibute of the object to active
            if (invisible_platform != null)
            {
                invisible_platform.SetActive(true);
            }
            if (activate_spring != null)
            {
                activate_spring.SetActive(true);
            }

        }

        if (collision.gameObject.CompareTag("rolling_circle"))
        {
            //  set attruibute of the object to active
            activate_platform.SetActive(true);

        }

    }
}
