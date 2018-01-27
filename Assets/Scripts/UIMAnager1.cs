using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMAnager1 : MonoBehaviour {

    public int activeButtonPanel;

    public GameObject skillButton11;
    public GameObject skillButton12;
    public GameObject skillButton13;
    public GameObject skillButton21;
    public GameObject skillButton22;
    public GameObject skillButton23;
    public GameObject skillButton31;
    public GameObject skillButton32;
    public GameObject skillButton33;
    public GameObject Disractor;

    private bool aiming;
    private int currentSkill;
    private int currentSkillType;

    private void Start()
    {
        aiming = false;
    }

    private void Update()
    {
        ListenForClick();  
    }

    private void ListenForClick()
    {
        Vector3 AimPosition;

        if (Input.GetKeyUp(KeyCode.Mouse0) && aiming)
        {
            AimPosition = Input.mousePosition;
            aiming = false;
            CreateDistraction(AimPosition);
        }
        
        else if (Input.GetKeyUp(KeyCode.Mouse1) && aiming)
        {
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
        aiming = true;
        currentSkill = 1;
        currentSkillType = type;
    }

    private void UseSkill2(int type)
    {
        aiming = true;
        currentSkill = 2;
        currentSkillType = type;
    }

    private void UseSkill3(int type)
    {
        aiming = true;
        currentSkill = 3;
        currentSkillType = type;
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
