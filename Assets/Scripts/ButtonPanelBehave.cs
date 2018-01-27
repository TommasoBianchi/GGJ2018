using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPanelBehave : MonoBehaviour {

    public GameObject canvas;

    private void OnMouseExit()
    {
        canvas.GetComponent<UIMAnager1>().activeButtonPanel = 0;
        gameObject.SetActive(false);
    }

}
