using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPlayerScript : MonoBehaviour
{
    private void Start() {
        this.GetComponent<ShooterScript>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "ShootPowerUp")
        {
            this.GetComponent<ShooterScript>().enabled = true;
            Destroy(other.gameObject, 0.5f);
        }
    }
}
