using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconOnMouse : MonoBehaviour {

    private Vector2 mousePosition;

	// Use this for initialization
	void Start () {
        GetMousePosition();
	}
	
	// Update is called once per frame
	void Update () {
        GetMousePosition();
        transform.position = mousePosition;
	}

    private void GetMousePosition ()
    {
        //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = Input.mousePosition;
    }
}
