using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFlash : MonoBehaviour
{
    // Start is called before the first frame update
    float duration = 2f; // Total duration of flashing effect
    float frequency = 0.2f;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.die_hint)
        {
            Debug.Log("Player.die_hint");
            StartCoroutine(FlashWhiteSpirit(3f, frequency, spriteRenderer));
            Player.die_hint = false;
        }
    }
    IEnumerator FlashWhiteSpirit(float duration, float frequency, SpriteRenderer spriteRenderer)
    {
        Debug.Log("FlashWhiteSpirit");
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
                spriteRenderer.color = Color.white;
                visible = !visible;
            }
            // spriteRenderer.enabled = visible;
            // visible = !visible;
            elapsed += frequency * 2;
            yield return new WaitForSeconds(0.01f);
        }
        spriteRenderer.color = Color.white;
    }

}
