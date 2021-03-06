﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMAnager1 : MonoBehaviour {

    public int activeButtonPanel;
    public float cd; //cd for the first skill
    public int killCount; //global killcount
    public int skill2Kill; //kill required to utilize the second skill
    public int skill3Kill; // kill required to utilize the third skill

    public GameObject skillButton11;//first numer indicates the kind of people, the second one the type of skill  
    public GameObject skillButton12;   
    public GameObject skillButton13;   
    public GameObject skillButton21;   
    public GameObject skillButton22;    
    public GameObject skillButton23;    
    public GameObject skillButton31;    
    public GameObject skillButton32; 
    public GameObject skillButton33;
    public GameObject Disractor;
    public GameObject trashBin;
    public GameObject[] skillPanels = new GameObject[3];
    public GameObject[] activeIcon = new GameObject[10];

    private bool aiming; //anti accdental click mechanic
    private bool ready; //if true athe next left key up a distractor willl be placed
    private int currentSkill; //numero skill
    private int currentSkillType;//tipo di persona
    public float offCd1; //tme at witch each first skill of each people kind will be ready
    public float offCd2;
    public float offCd3;
    public int skill2LastUseKill1; //kill count at the whitch the skill will be ready
    public int skill2LastUseKill2;
    public int skill2LastUseKill3;
    public int skill3LastUseKill1; //kill count at the whitch the skill will be ready
    public int skill3LastUseKill2;
    public int skill3LastUseKill3;
    private int iconOnMouse;
    private bool paused; //Game status

    private System.Action OnSkillLaunched;

    private void Start()
    {
        aiming = false;
        ready = false;
        offCd1 = offCd2 = offCd3 = 0;
        killCount = 0;
        skill2LastUseKill1 = skill2LastUseKill2 = skill2LastUseKill3 = 0;
        skill3LastUseKill1 = skill3LastUseKill2 = skill3LastUseKill3 = 0;
        paused = false;
    }

    private void Update()
    {
        ListenForClick();
        killCount = GameManager.killCounter;
    }

    private void ListenForClick()
    {
        Vector3 AimPosition;

        if (Input.GetKeyUp(KeyCode.Mouse0) && ready)
        {
            AimPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ready = false;
            CreateDistraction(AimPosition);
        }

        else if (Input.GetKeyUp(KeyCode.Mouse0) && aiming)
        {
            ready = true;
            aiming = false;
        }

        else
        {
            return;
        }
    }

    private void CreateDistraction(Vector3 Aim)
    {
        GameObject Attractor;

        Aim.z = 0;
        Attractor = Instantiate(Disractor, Aim, Quaternion.identity);
        Attractor.transform.GetComponentInChildren<SpriteRenderer>().sprite = activeIcon[(currentSkillType - 1) * 3 + (currentSkill - 1)].GetComponent<Image>().sprite;
        Attractor.GetComponent<Attracor>().type = currentSkillType;
        Attractor.GetComponent<Attracor>().skillType = currentSkill;
        activeIcon[iconOnMouse].SetActive(false);
        activeIcon[9].SetActive(false);
        activeIcon[10].SetActive(false);
        activeIcon[11].SetActive(false);
        trashBin.SetActive(false);
        OnSkillLaunched();

    }

    public void TrashSkill ()
    {
        activeIcon[iconOnMouse].SetActive(false);
        aiming = false;
        ready = false;
        trashBin.SetActive(false);
        activeIcon[9].SetActive(false);
        activeIcon[10].SetActive(false);
        activeIcon[11].SetActive(false);
    }

    private void UseSkill1(int type)
    {
        Vector3 scale = new Vector3 (5, 5, 0);
        switch (type)
        {
            case 1:
                if (Time.time >= offCd1)
                {
                    aiming = true;
                    currentSkill = 1;
                    currentSkillType = type;
                    OnSkillLaunched = () => offCd1 = Time.time + cd;
                    activeIcon[0].SetActive(true);
                    activeIcon[9].SetActive(true);
                    activeIcon[9].transform.localScale = scale; 
                    iconOnMouse = 0;
                    trashBin.SetActive(true);
                    //skillPanels[1].transform.GetComponent<SkillPanelBehaviour>().ready = false;
                }
                break;
            case 2:
                if (Time.time >= offCd2)
                {
                    aiming = true;
                    currentSkill = 1;
                    currentSkillType = type;
                    OnSkillLaunched = () => offCd2 = Time.time + cd;
                    activeIcon[3].SetActive(true);
                    activeIcon[10].SetActive(true);
                    activeIcon[10].transform.localScale = scale;
                    iconOnMouse = 3;
                    trashBin.SetActive(true);
                }
                break;
           case 3:
                if (Time.time >= offCd3)
                {
                    aiming = true;
                    currentSkill = 1;
                    currentSkillType = type;
                    OnSkillLaunched = () => offCd3 = Time.time + cd;
                    activeIcon[6].SetActive(true);
                    activeIcon[11].SetActive(true);
                    activeIcon[11].transform.localScale = scale;
                    iconOnMouse = 6;
                    trashBin.SetActive(true);
                }
                break;

        }
    }

    private void UseSkill2(int type)
    {
        Vector3 scale = new Vector3(12, 12, 0);
        switch (type)
        {
            case 1:
                if (killCount >= skill2LastUseKill1 + skill2Kill)
                {
                    aiming = true;
                    currentSkill = 2;
                    currentSkillType = type;
                    OnSkillLaunched = () => skill2LastUseKill1 = killCount + skill2Kill;
                    activeIcon[1].SetActive(true);
                    activeIcon[9].SetActive(true);
                    activeIcon[9].transform.localScale = scale;
                    iconOnMouse = 1;
                    trashBin.SetActive(true);
                }
                break;
            case 2:
                if (killCount >= skill2LastUseKill2 + skill2Kill)
                {
                    aiming = true;
                    currentSkill = 2;
                    currentSkillType = type;
                    OnSkillLaunched = () => skill2LastUseKill2 = killCount + skill2Kill;
                    activeIcon[4].SetActive(true);
                    activeIcon[10].SetActive(true);
                    activeIcon[10].transform.localScale = scale;
                    iconOnMouse = 4;
                    trashBin.SetActive(true);
                }
                break;
            case 3:
                if (killCount >= skill2LastUseKill3 + skill2Kill)
                {
                    aiming = true;
                    currentSkill = 2;
                    currentSkillType = type;
                    OnSkillLaunched = () => skill2LastUseKill3 = killCount + skill2Kill;
                    activeIcon[7].SetActive(true);
                    activeIcon[11].SetActive(true);
                    activeIcon[11].transform.localScale = scale;
                    iconOnMouse = 7;
                    trashBin.SetActive(true);
                }
                break;

        }
    }

    private void UseSkill3(int type)
    {
        Vector3 scale = new Vector3(20, 20, 0);
        switch (type)
        {
            case 1:
                if (killCount >= skill3LastUseKill1 + skill3Kill)
                {
                    aiming = true;
                    currentSkill = 3;
                    currentSkillType = type;
                    OnSkillLaunched = () => skill3LastUseKill1 = killCount + skill3Kill;
                    activeIcon[2].SetActive(true);
                    activeIcon[9].SetActive(true);
                    activeIcon[9].transform.localScale = scale;
                    iconOnMouse = 2;
                    trashBin.SetActive(true);
                }
                break;
            case 2:
                if (killCount >= skill3LastUseKill2 + skill3Kill)
                {
                    aiming = true;
                    currentSkill = 3;
                    currentSkillType = type;
                    OnSkillLaunched = () => skill3LastUseKill2 = killCount + skill3Kill;
                    activeIcon[5].SetActive(true);
                    activeIcon[10].SetActive(true);
                    activeIcon[10].transform.localScale = scale;
                    iconOnMouse = 5;
                    trashBin.SetActive(true);
                }
                break;
            case 3:
                if (killCount >= skill3LastUseKill3 + skill3Kill)
                {
                    aiming = true;
                    currentSkill = 3;
                    currentSkillType = type;
                    OnSkillLaunched = () => skill3LastUseKill3 = killCount + skill3Kill;
                    activeIcon[8].SetActive(true);
                    activeIcon[11].SetActive(true);
                    activeIcon[11].transform.localScale = scale;
                    iconOnMouse = 8;
                    trashBin.SetActive(true);
                }
                break;
        }
    }

    public void Skill11 ()
    {
        UseSkill1(1);
    }

    public void Skill12()
    {
        UseSkill2(1);
    }

    public void Skill13()
    {
        UseSkill3(1);
    }

    public void Skill21()
    {
        UseSkill1(2);
    }

    public void Skill22()
    {
        UseSkill2(2);
    }

    public void Skill23()
    {
        UseSkill3(2);
    }

    public void Skill31()
    {
        UseSkill1(3);
    }

    public void Skill32()
    {
        UseSkill2(3);
    }

    public void Skill33()
    {
        UseSkill3(3);
    }

    public void Pause()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
        }
        else
        {
            Time.timeScale = 1;
            paused = false;
        }
    }


    
}
