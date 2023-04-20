using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count_1 : MonoBehaviour
{
    public static int Count = 0;
    public static bool successfully = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player11111111:" + Player.perfect_jumps);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Player.perfect_jumps != 1)
            {
                // get the transform of the player
                Transform player_transform = other.gameObject.GetComponent<Transform>();
                //set the position of the player
                player_transform.position = new Vector2(184.5f, -10.15316f);
                successfully = false;
            }
            {
                successfully = true;
                Count++;
                Debug.Log("Count:" + Count);
            }
        }
    }
}
