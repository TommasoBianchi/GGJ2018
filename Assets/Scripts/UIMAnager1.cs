using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMAnager1 : MonoBehaviour {

    public int activeButtonPanel;
    public float cd; //cd for the first skill
    public int killCount; //global killcount
    public int skill2Kill; //kill required to utilize the second skill
    public int skill3Kill; // kill required to utilize the third skill

    public GameObject skillButton11; //first numer indicates the kind of people, the second one the type of skill
    public GameObject skillButton12;
    public GameObject skillButton13;
    public GameObject skillButton21;
    public GameObject skillButton22;
    public GameObject skillButton23;
    public GameObject skillButton31;
    public GameObject skillButton32;
    public GameObject skillButton33;
    public GameObject Disractor;

    private bool aiming; //anti accdental click mechanic
    private bool ready; //if true athe next left key up a distractor willl be placed
    private int currentSkill; 
    private int currentSkillType;
    private float offCd1; //tme at witch each first skill of each people kind will be ready
    private float offCd2;
    private float offCd3;
    private int skill2LastUseKill1; //kill count at the moment of use of skill 2 in each kind of people
    private int skill2LastUseKill2;
    private int skill2LastUseKill3;
    private int skill3LastUseKill1; //kill count at the momento of use of skill 3 in each kind of people
    private int skill3LastUseKill2;
    private int skill3LastUseKill3;

    private void Start()
    {
        aiming = false;
        ready = false;
        offCd1 = offCd2 = offCd3 = 0;
        killCount = 0;
        skill2LastUseKill1 = skill2LastUseKill2 = skill2LastUseKill3 = 0;
        skill3LastUseKill1 = skill3LastUseKill2 = skill3LastUseKill3 = 0;
    }

    private void Update()
    {
        ListenForClick();  
    }

    private void ListenForClick()
    {
        Vector3 AimPosition;

        if (Input.GetKeyUp(KeyCode.Mouse0) && ready)
        {
            AimPosition = Input.mousePosition;
            ready = false;
            CreateDistraction(AimPosition);
        }
        
        else if (Input.GetKeyUp(KeyCode.Mouse1) && ready)
        {
            ready = false;
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
        Debug.Log("istanzio");
        Debug.Log(Aim+" "+currentSkill+" "+currentSkillType);
        GameObject Attractor;

        Aim.z = 0;
        Attractor = Instantiate(Disractor, Aim, Quaternion.identity);
        Attractor.GetComponent<Attracor>().type = currentSkillType;
        Attractor.GetComponent<Attracor>().skillType = currentSkill;
    }

    private void UseSkill1(int type)
    {
        switch (type)
        {
            case 1:
                if (Time.time >= offCd1)
                {
                    aiming = true;
                    currentSkill = 1;
                    currentSkillType = type;
                    offCd1 = Time.time + cd;
                }
                break;
            case 2:
                if (Time.time >= offCd2)
                {
                    aiming = true;
                    currentSkill = 1;
                    currentSkillType = type;
                    offCd2 = Time.time + cd;
                }
                break;
           case 3:
                if (Time.time >= offCd3)
                {
                    aiming = true;
                    currentSkill = 1;
                    currentSkillType = type;
                    offCd3 = Time.time + cd;
                }
                break;

        }
    }

    private void UseSkill2(int type)
    {
        switch (type)
        {
            case 1:
                if (killCount >= skill2LastUseKill1 + skill2Kill)
                {
                    aiming = true;
                    currentSkill = 2;
                    currentSkillType = type;
                    skill2LastUseKill1 = killCount;
                }
                break;
            case 2:
                if (killCount >= skill2LastUseKill2 + skill2Kill)
                {
                    aiming = true;
                    currentSkill = 2;
                    currentSkillType = type;
                    skill2LastUseKill2 = killCount;
                }
                break;
            case 3:
                if (killCount >= skill2LastUseKill3 + skill2Kill)
                {
                    aiming = true;
                    currentSkill = 2;
                    currentSkillType = type;
                    skill2LastUseKill3 = killCount;
                }
                break;

        }
    }

    private void UseSkill3(int type)
    {
        switch (type)
        {
            case 1:
                if (killCount >= skill3LastUseKill1 + skill3Kill)
                {
                    aiming = true;
                    currentSkill = 3;
                    currentSkillType = type;
                    skill3LastUseKill1 = killCount;
                }
                break;
            case 2:
                if (killCount >= skill3LastUseKill2 + skill3Kill)
                {
                    aiming = true;
                    currentSkill = 3;
                    currentSkillType = type;
                    skill3LastUseKill2 = killCount;
                }
                break;
            case 3:
                if (killCount >= skill3LastUseKill3 + skill3Kill)
                {
                    aiming = true;
                    currentSkill = 3;
                    currentSkillType = type;
                    skill3LastUseKill3 = killCount;
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

}
