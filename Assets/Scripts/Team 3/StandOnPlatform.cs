using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandOnPlatform : MonoBehaviour
{
    // Start is called before the first frame update
private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Get  player");
            collision.transform.SetParent(transform);
        }
    }

private void OnTriggerExit(Collider other)
{
    if (!other.CompareTag("Player")) return;
    other.transform.parent = null;
}



}
