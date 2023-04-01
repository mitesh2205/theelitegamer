using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public static float SpeedBoost = 15f;
    public static float DefaultSpeed = 12f;
   
    // private void OnCollisionEnter2D(Collider2D collision)
    // {
    //     // compare tag to player
    //     if(collision.gameObject.CompareTag("Player")){
    //         Player.moveForce = SpeedBoost;
    //         Debug.Log("on slope");
    //     }
    // }
    // private void OnCollisionExit2D(Collider2D collision)
    // {
    //     if(collision.gameObject.CompareTag("Player")){
    //         Player.moveForce = SpeedBoost;
    //         Debug.Log("on slope");
    //     }
    // }
}