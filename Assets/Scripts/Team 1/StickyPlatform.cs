using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    public Vector3 originalSize = new Vector3(1, 1, 1);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("this is player");
            // collision.transform.SetParent(transform);

            collision.gameObject.transform.localScale = originalSize;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}

