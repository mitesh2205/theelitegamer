using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float force = 10f;
    public float flyTime = 3f;
    private bool isFlying = false;
    private bool isFuelEmpty = false;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !isFuelEmpty)
        {
            isFlying = true;
            rigidbody2D.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
            StartCoroutine(FlyDuration());
        }

        if (Input.GetKeyUp(KeyCode.J) || isFuelEmpty)
        {
            isFlying = false;
        }

        if (!isFlying)
        {
            rigidbody2D.velocity += Physics2D.gravity * Time.deltaTime;
        }
    }

    IEnumerator FlyDuration()
    {
        yield return new WaitForSeconds(flyTime);
        isFuelEmpty = true;
        StartCoroutine(RefuelDuration());
    }

    IEnumerator RefuelDuration()
    {
        yield return new WaitForSeconds(flyTime);
        isFuelEmpty = false;
    }
}






