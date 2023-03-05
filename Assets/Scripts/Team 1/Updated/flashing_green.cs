using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashing_green : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    float duration = 4f; // Total duration of flashing effect
    float frequency = 0.2f; // How often the sprite should toggle (i.e. how quickly the flashing effect occurs)
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.timeleft <= 2f && Timer.green_safe)
        {
            StartCoroutine(FlashSprite(duration, frequency, spriteRenderer));
            // float elapsed = 0f;
            // bool visible = true;
            // while (elapsed < duration)
            // {
            //     spriteRenderer.enabled = visible;
            //     visible = !visible;
            //     elapsed += frequency;
            //     yield return new WaitForSeconds(frequency);
            // }
            // spriteRenderer.enabled = true;
        }
        if (Player.blink_green)
        {
            StartCoroutine(FlashWhiteSpirit(3f, frequency, spriteRenderer));
        }

    }
    IEnumerator FlashWhiteSpirit(float duration, float frequency, SpriteRenderer spriteRenderer)
    {
        float elapsed = 0f;
        bool visible = true;
        while (elapsed < duration)
        {
            if (visible)
            {
                spriteRenderer.color = Color.white;
                visible = !visible;

            }
            else
            {
                spriteRenderer.color = Color.green;
                visible = !visible;
            }
            // spriteRenderer.enabled = visible;
            // visible = !visible;
            elapsed += frequency * 2;
            yield return new WaitForSeconds(0.01f);
        }
        spriteRenderer.color = Color.green;
    }
    IEnumerator FlashSprite(float duration, float frequency, SpriteRenderer spriteRenderer)
    {
        float elapsed = 0f;
        bool visible = true;
        while (elapsed < duration)
        {
            if (visible)
            {
                spriteRenderer.color = Color.red;
                visible = !visible;

            }
            else
            {
                spriteRenderer.color = Color.green;
                visible = !visible;
            }
            // spriteRenderer.enabled = visible;
            // visible = !visible;
            elapsed += frequency * 2;
            yield return new WaitForSeconds(0.01f);
        }
        spriteRenderer.color = Color.green;
    }
}
