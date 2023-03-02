using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerColorChange : MonoBehaviour
{
    public Color targetColor;

    void Start()
    {
        StartCoroutine(ChangeColor(15f));
    }
    // IEnumerator ChangeColor()
    // {
    //     while (true)
    //     {
    //         SpriteRenderer renderer = GetComponent<SpriteRenderer>();
    //         Color currentColor = renderer.color;
    //         Color newColor = Color.Lerp(currentColor, targetColor, (Time.deltaTime) * 0.05f);
    //         renderer.color = newColor;
    //         yield return null;
    //     }
    // }
    // IEnumerator ChangeColor(float duration)
    // {
    //     float elapsed = 0f;
    //     SpriteRenderer renderer = GetComponent<SpriteRenderer>();
    //     Color startColor = renderer.color;
    //     Vector2 spriteSize = renderer.sprite.bounds.size;
    //     while (elapsed < duration)
    //     {
    //         float ratio = elapsed / duration;
    //         float startY = renderer.transform.position.y + (spriteSize.y * (ratio - 0.5f));
    //         float endY = renderer.transform.position.y + (spriteSize.y * (ratio + 0.5f));
    //         Vector3 startWorld = new Vector3(0f, startY, 0f);
    //         Vector3 endWorld = new Vector3(0f, endY, 0f);
    //         Vector3 startPos = renderer.transform.InverseTransformPoint(startWorld);
    //         Vector3 endPos = renderer.transform.InverseTransformPoint(endWorld);
    //         renderer.color = startColor;
    //         for (int i = 0; i < renderer.sprite.vertices.Length; i++)
    //         {
    //             Vector3 vertex = renderer.sprite.vertices[i];
    //             Vector3 localVertex = renderer.transform.InverseTransformPoint(renderer.transform.position + vertex);
    //             float t = Mathf.InverseLerp(startPos.y, endPos.y, localVertex.y);
    //             if (t >= 0f && t <= 1f)
    //             {
    //                 renderer.sprite.vertices[i] = vertex + ((endPos - startPos) * t);
    //                 renderer.sprite.colors[i] = Color.Lerp(startColor, targetColor, t);
    //             }
    //         }
    //         renderer.sprite.RecalculateBounds();
    //         elapsed += Time.deltaTime;
    //         yield return null;
    //     }
    //     renderer.color = targetColor; // Ensure the color is set exactly to target at the end
    // }
    IEnumerator ChangeColor(float duration)
    {
        float elapsed = 0f;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        Material material = renderer.material;
        Color startColor = renderer.color;
        Gradient gradient = new Gradient();
        GradientColorKey[] colorKeys = new GradientColorKey[2];
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
        colorKeys[0] = new GradientColorKey(startColor, 0f);
        colorKeys[1] = new GradientColorKey(targetColor, 1f);
        alphaKeys[0] = new GradientAlphaKey(startColor.a, 0f);
        alphaKeys[1] = new GradientAlphaKey(targetColor.a, 1f);
        gradient.SetKeys(colorKeys, alphaKeys);
        while (elapsed < duration)
        {
            float ratio = elapsed / duration;
            material.SetTextureOffset("_MainTex", new Vector2(0f, ratio));
            material.SetTextureScale("_MainTex", new Vector2(1f, 1f));
            material.SetColor("_Color", gradient.Evaluate(ratio));
            elapsed += Time.deltaTime;
            yield return null;
        }
        renderer.color = targetColor; // Ensure the color is set exactly to target at the end
    }



}
