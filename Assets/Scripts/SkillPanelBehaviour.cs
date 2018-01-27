using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanelBehaviour : MonoBehaviour {

    public GameObject skill1;
    public GameObject skill2;
    public GameObject skill3;
    public GameObject Canvas;

    private float endCd;
    private float cd;
    private bool ready;
    

    void Start () {
        endCd = Canvas.GetComponent<UIMAnager1>().offCd1;
        cd = Canvas.GetComponent<UIMAnager1>().cd;
        ready = true;
    }
	
	
	void Update () {
        if (ready)
        {
            timeCD();
        }
	}

    public void timeCD ()
    {
        float fillAmount;
        fillAmount = 1 - ((endCd - Time.time) / cd);
        skill1.transform.GetComponent<Image>().fillAmount = fillAmount;
        if (fillAmount == 1)
        {
            ready = false;
            skill1.transform.GetComponent<Image>().fillAmount = 0;
        }

    }
}
