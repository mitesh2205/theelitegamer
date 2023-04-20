using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashing_blue : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    float duration = 4f; // Total duration of flashing effect
    float frequency = 0.2f; // How often the sprite should toggle (i.e. how quickly the flashing effect occurs)
    Color blueColor = new Color();
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ColorUtility.TryParseHtmlString("#0088F3", out blueColor);

    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.timeleft <= 2f && Timer.blue_safe)
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
        if (Player.blink_blue)
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
                spriteRenderer.color = blueColor;
                visible = !visible;
            }
            // spriteRenderer.enabled = visible;
            // visible = !visible;
            elapsed += frequency * 2;
            yield return new WaitForSeconds(0.01f);
        }
        spriteRenderer.color = blueColor; // Ensure sprite is visible at the end
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
                spriteRenderer.color = blueColor;
                visible = !visible;
            }
            // spriteRenderer.enabled = visible;
            // visible = !visible;
            elapsed += frequency * 2;
            yield return new WaitForSeconds(0.01f);
        }
        spriteRenderer.color = blueColor; // Ensure sprite is visible at the end
    }
}
