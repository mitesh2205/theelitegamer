using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFlash : MonoBehaviour
{
    // Start is called before the first frame update
    float duration = 2f; // Total duration of flashing effect
    float frequency = 50f;
    private SpriteRenderer spriteRenderer;
    Color blueColor = new Color();
    void Start()
    {
        ColorUtility.TryParseHtmlString("#0088F3", out blueColor);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.die_hint)
        {
            Debug.Log("Player.die_hint");
            StartCoroutine(FlashWhiteSpirit(4f, frequency, spriteRenderer));
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
                // spriteRenderer.color = Color.white;
                if(Timer.blue_safe){
                    spriteRenderer.color = blueColor;
                }
                else{
                    spriteRenderer.color = Color.green;
                }
                visible = !visible;
            }
            // spriteRenderer.enabled = visible;
            // visible = !visible;
            elapsed += frequency * Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
        if(Timer.blue_safe){
            spriteRenderer.color = blueColor;
        }
        else if(Timer.green_safe){
            spriteRenderer.color = Color.green;
        }
        else{
            spriteRenderer.color = Color.white;
        }
    }

}
