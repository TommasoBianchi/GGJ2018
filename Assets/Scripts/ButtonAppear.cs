using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAppear : MonoBehaviour {

    public GameObject buttonPanel1;
    public GameObject buttonPanel2;
    public GameObject buttonPanel3;
    public GameObject canvas;
    public int buttonNumber;

    private void OnMouseOver()
    {
        switch (canvas.GetComponent<UIMAnager1>().activeButtonPanel)
        {
            case 1:
                buttonPanel1.SetActive(false);
                break;
            case 2:
                buttonPanel2.SetActive(false);
                break;
            case 3:
                buttonPanel3.SetActive(false);
                break;

        }
        canvas.GetComponent<UIMAnager1>().activeButtonPanel = buttonNumber;
        switch (buttonNumber)
        {
            case 1:
                buttonPanel1.SetActive(true);
                break;
            case 2:
                buttonPanel2.SetActive(true);
                break;
            case 3:
                buttonPanel3.SetActive(true);
                break;

        }
        
    }

}
