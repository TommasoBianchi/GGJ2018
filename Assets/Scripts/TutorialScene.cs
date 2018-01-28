using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScene : MonoBehaviour {

    public GameObject secondPage;
    public GameObject firstPage;
    public float fisrtTimer;
    public float secondTimer;
    private float start;
	// Use this for initialization
	void Start () {
        start = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= start+fisrtTimer)
        {
            firstPage.SetActive(false);
            secondPage.SetActive(true);
        }
        
        if (Time.time >= start+secondTimer+fisrtTimer)
        {
            SceneManager.LoadScene(3);
        }
	}
}
