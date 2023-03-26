using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_for_reward : MonoBehaviour
{
    public GameObject try_again;
    // Start is called before the first frame update
    void Start()
    {
        try_again.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Count_1.Count = 0;
            Player.perfect_jumps = 0;
            try_again.SetActive(false);
        }
    }

}
