using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemaphoreLight : MonoBehaviour {

    public Semaphore.SemaphoreType type;
    public Sprite redSemaphore;
    public Sprite greenSemaphore;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
	public void ChangeLight(Semaphore.SemaphoreType greenType)
    {
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();

        if (greenType == type)
        {
            spriteRenderer.sprite = greenSemaphore;
        }
        else
        {
            spriteRenderer.sprite = redSemaphore;
        }
    }
}
