using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update

    // public AudioClip StartSound;
    // private AudioSource audioSource;

    public static int allowed_shots = 500;
    public Transform firePoint;
    public GameObject bulletPrefab;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && allowed_shots > 0)
        {
            // audioSource = GetComponent<AudioSource>();
            // audioSource.PlayOneShot(StartSound);
            Shoot();
            allowed_shots--;
            // yield return new WaitForSeconds(1.5f);
            // Destroy(this.bulletPrefab);
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // shoot after 2 seconds delay
        // StartCoroutine(ShootDelay());
        // yield return new WaitForSeconds(1.5f);
        // Destroy(this.bulletPrefab);
        // StartCoroutine(ShootDestroy());
    }


}
