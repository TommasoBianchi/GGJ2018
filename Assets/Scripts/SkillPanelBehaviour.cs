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
    private int skill2nextUse;
    private int skill3nextUse;//number of kill at whitch the skill will be ready
    private float cd;
    private int killcd2;//kill required to charge the skill
    private int killcd3;
    public bool ready;
    

    void Start () {
        cd = Canvas.GetComponent<UIMAnager1>().cd;
        killcd2 = Canvas.GetComponent<UIMAnager1>().skill2Kill;
        killcd3 = Canvas.GetComponent<UIMAnager1>().skill3Kill;
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

    public void Skill2CD ()
    {
        float fillAmount;
        fillAmount = 1 - ((skill2nextUse - GameManager.killCounter) / killcd2);
        skill2.transform.GetComponent<Image>().fillAmount = fillAmount;
        if (fillAmount > 1)
        {
            skill2.SetActive(false);
        }
        else
        {
            skill2.SetActive(true);
        }
    }

    public void Skill3CD()
    {
        float fillAmount;
        fillAmount = 1 - ((skill3nextUse - GameManager.killCounter) / killcd3);
        skill3.transform.GetComponent<Image>().fillAmount = fillAmount;
        if (fillAmount > 1)
        {
            skill3.SetActive(false);
        }
        else
        {
            skill3.SetActive(true);
        }
    }

    private void Setup ()
    {
        switch (skillPanel)
        {
            case 1:
                endCd = Canvas.GetComponent<UIMAnager1>().offCd1;
                skill2nextUse = Canvas.GetComponent<UIMAnager1>().skill2LastUseKill1;
                skill3nextUse = Canvas.GetComponent<UIMAnager1>().skill3LastUseKill1;
                break;
            case 2:
                endCd = Canvas.GetComponent<UIMAnager1>().offCd2;
                skill2nextUse = Canvas.GetComponent<UIMAnager1>().skill2LastUseKill2;
                skill3nextUse = Canvas.GetComponent<UIMAnager1>().skill3LastUseKill2;
                break;
            case 3:
                endCd = Canvas.GetComponent<UIMAnager1>().offCd3;
                skill2nextUse = Canvas.GetComponent<UIMAnager1>().skill2LastUseKill3;
                skill3nextUse = Canvas.GetComponent<UIMAnager1>().skill3LastUseKill3;
                break;
        }
    }
}
