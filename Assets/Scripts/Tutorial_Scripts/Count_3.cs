using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count_3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Player.perfect_jumps == 0 && Count_1.Count != 2)
            {
                // get the transform of the player
                Transform player_transform = other.gameObject.GetComponent<Transform>();
                //set the position of the player
                player_transform.position = new Vector2(184.5f, -10.15316f);

                Count_1.successfully = false;
            }
            else
            {
                Count_1.successfully = true;
            }
        }
    }
}
