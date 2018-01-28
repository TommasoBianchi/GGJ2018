using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

    public AudioClip[] samples;

    public SFXManager Instance { get; private set; }

    void Start()
    {
        Instance = this;
    }

    public void PlaySample(int index)
    {
        if (index < samples.Length)
        {
            AudioSource.PlayClipAtPoint(samples[index], Vector3.zero);
        }
    }
}
