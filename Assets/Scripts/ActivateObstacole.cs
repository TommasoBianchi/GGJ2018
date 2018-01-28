using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObstacole : MonoBehaviour {

    public Sprite alternativeSprite;
    public SpriteRenderer spriteRenderer;
    public Color disabledColor;

    private Sprite normalSprite;

    void Start()
    {
        if (spriteRenderer) normalSprite = spriteRenderer.sprite;
    }
    
	public void Activate()
    {
        if (alternativeSprite && spriteRenderer)
        {
            spriteRenderer.sprite = alternativeSprite;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }

    public void Deactivate()
    {
        if (alternativeSprite && spriteRenderer)
        {
            spriteRenderer.sprite = normalSprite;
        }
        else
        {
            spriteRenderer.color = disabledColor;
        }
    }
}
