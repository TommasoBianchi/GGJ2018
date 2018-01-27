using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Semaphore : MonoBehaviour {

    public enum SemaphoreType
    {
        Horizontal,
        Vertical
    }

    public event Action OnSemaphoreHorizontalGreen;
    public event Action OnSemaphoreVerticalGreen;

    public float toggleTime;

    public SemaphoreType greenSemaphore;// { get; private set; }

    private float nextToggleTime;

    void Start ()
    {
        greenSemaphore = (SemaphoreType)UnityEngine.Random.Range(0, 2);
        nextToggleTime = Time.time + toggleTime - UnityEngine.Random.Range(0, toggleTime / 3f);
	}
	
	void Update ()
    {
        nextToggleTime -= Time.deltaTime;

        if (Time.time > nextToggleTime)
        {
            nextToggleTime = Time.time + toggleTime;

            ToggleSemaphore();
        }
	}

    private void ToggleSemaphore()
    {
        if(greenSemaphore == SemaphoreType.Horizontal)
        {
            greenSemaphore = SemaphoreType.Vertical;
            if (OnSemaphoreVerticalGreen != null)
            {
                OnSemaphoreVerticalGreen.Invoke();
            }
        }
        else
        {
            greenSemaphore = SemaphoreType.Horizontal;
            if (OnSemaphoreHorizontalGreen != null)
            {
                OnSemaphoreHorizontalGreen.Invoke();
            }
        }
    }
}
