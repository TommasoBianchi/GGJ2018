using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScene : MonoBehaviour {

    public GameObject secondPage;
    public GameObject firstPage;
    public float fisrtTimer;
    public float secondTimer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= fisrtTimer)
        {
            firstPage.SetActive(false);
            secondPage.SetActive(true);
        }
        
        if (Time.time >= secondTimer)
        {
            SceneManager.LoadScene(3);
        }
	}
}
