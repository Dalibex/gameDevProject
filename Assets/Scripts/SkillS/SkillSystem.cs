using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    private bool ActivatePanel;
    public GameObject SkillPanel;
    public  List<GameObject> Skills=new List<GameObject>();
    private  List<GameObject> SkillsP=new List<GameObject>();
    public  List<SkillObject> activatedSkills2=new List<SkillObject>();
    private int activeCount=0,active0=0,active1=0,active2=0,active3=0;
    void Awake(){
        int count = SkillPanel.transform.childCount;
        for (int i=0; i<count;i++)
        {
            SkillsP.Add(SkillPanel.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ActivatePanel)
        {
            SkillPanel.SetActive(true);
            PlayerMove.setPlayerMovement(false);
            Skills.Add(SkillPanel.transform.GetChild(0).gameObject);
        }else
        {
            SkillPanel.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ActivatePanel=!ActivatePanel;
        }
        provisionalActiveSystem();
    }
    
    private void provisionalActiveSystem(){
        if (Skills[0].transform.GetChild(3).gameObject.activeSelf)
            {
                active0=1;
            }else active0=0;
        if (Skills[1].transform.GetChild(3).gameObject.activeSelf)
            {
                active1=1;
            }else active1=0;
        if (Skills[2].transform.GetChild(3).gameObject.activeSelf)
            {
                active2=1;
            }else active2=0;
        if (Skills[3].transform.GetChild(3).gameObject.activeSelf)
            {
                 active3=1;
            }else active3=0;
    }
    public int getActiveCount(){
        activeCount=active0+active1+active2+active3;
        return activeCount;
    }
    public List<SkillObject> getSkillsActivated(){
        List<SkillObject> skillsAux=new List<SkillObject>();
        foreach (GameObject skill in SkillsP)
        {
            skillsAux.Add(skill.GetComponent<SkillManager>().getSkill());
        }
        return skillsAux;
    }
}
