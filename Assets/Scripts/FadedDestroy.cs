using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadedDestroy : MonoBehaviour {

    public float fadeTime;

    private SpriteRenderer spriteRenderer;

    private float fadeTimer;
    
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();	
	}
	
	void Update ()
    {
        Color color = spriteRenderer.color;
        color.a = (fadeTime - fadeTimer) / fadeTime;
        spriteRenderer.color = color;

        fadeTimer += Time.deltaTime;
        if (fadeTimer >= fadeTime)
        {
            Destroy(gameObject);
        }
    }
}
