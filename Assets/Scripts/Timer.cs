using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float totalTime;
    private float timeLeft;
    public GameObject text;

    private float min;
    private float sec;

    private void Update()
    {
        Clock();
    }

    private void Clock()
    {
         timeLeft = totalTime - Time.time;
         min = timeLeft % 60;
         sec = 0.6f * ((timeLeft / 60) - min);

         text.transform.GetComponent<Text>().text = min.ToString() + " : " + sec.ToString();
        //timeLeft = (totalTime - Time.time);
        //text.transform.GetComponent<Text>().text = timeLeft.ToString();
    }
}
