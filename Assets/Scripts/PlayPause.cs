using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPause : MonoBehaviour {

    public Sprite Play;
    public Sprite Pause;

    private bool isPaused;

    private void Start()
    {
        isPaused = false;
    }

    public void ChangeIcon ()
    {
        if (isPaused)
        {
            gameObject.transform.GetComponent<Image>().sprite = Play;
            isPaused = false;
        }
        else
        {
            gameObject.transform.GetComponent<Image>().sprite = Pause;
            isPaused = true;
        }
    }
}
