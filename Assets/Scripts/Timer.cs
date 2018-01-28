using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public int totalTime;
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
        int time = (int)Time.time;

         timeLeft = totalTime - time;
         sec = timeLeft % 60;
         min = (int)(timeLeft - sec) / 60;
         

         text.transform.GetComponent<Text>().text = min.ToString() + " : " + sec.ToString();
        //timeLeft = (totalTime - Time.time);
        //text.transform.GetComponent<Text>().text = timeLeft.ToString();
    }
}
