using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanelBehaviour : MonoBehaviour {

    public GameObject skill1;
    public GameObject skill2;
    public GameObject skill3;
    public GameObject Canvas;
    public int skillPanel;

    private float endCd;
    private float cd;
    public bool ready;
    

    void Start () {
        cd = Canvas.GetComponent<UIMAnager1>().cd;
        ready = true;
    }
	
	
	void Update () {
        Setup();
        timeCD(); 
	}

    public void timeCD ()
    {
        float fillAmount;
        fillAmount = 1 - ((endCd - Time.time) / cd);
       // Debug.Log(fillAmount);
        skill1.transform.GetComponent<Image>().fillAmount = fillAmount;
        if (fillAmount > 1)
        {
            skill1.SetActive(false);
        }
        else
        {
            skill1.SetActive(true);
        }
    }

    private void Setup ()
    {
        switch (skillPanel)
        {
            case 1:
                endCd = Canvas.GetComponent<UIMAnager1>().offCd1;
                
                break;
            case 2:
                endCd = Canvas.GetComponent<UIMAnager1>().offCd2;
                
                break;
            case 3:
                endCd = Canvas.GetComponent<UIMAnager1>().offCd3;

                    break;
        }
    }
}
