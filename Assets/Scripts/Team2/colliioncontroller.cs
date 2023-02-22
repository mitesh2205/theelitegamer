using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliioncontroller : MonoBehaviour
{
    private void onCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("lower_block"))
        {
            Destroy(gameObject);
        }
    }
    
}
