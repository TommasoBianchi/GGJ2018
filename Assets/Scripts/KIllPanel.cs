using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KIllPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Text>().text = GameManager.killCounter.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Text>().text = GameManager.killCounter.ToString();
    }
}
