using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    public bool ActivatePanel;
    public GameObject SkillPanel;
    public  List<GameObject> Skills=new List<GameObject>();
    private int activeCount;

    // Update is called once per frame
    void Update()
    {
        if (ActivatePanel)
        {
            SkillPanel.SetActive(true);
            PlayerMove.setPlayerMovement(false);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ActivatePanel=false;
            }
        }else{
            SkillPanel.SetActive(false);
        }
        if (Input.GetKeyDown(InputManager.Instance.GetKey("SkillPanelButton")))
        {
            ActivatePanel=!ActivatePanel;
        }
    }
    public void activeSystem(){
        activeCount=0;
        foreach (GameObject skill in Skills)
        {
            if (skill.transform.GetChild(3).gameObject.activeSelf)
            {
                activeCount++;
            }
        }
    }
    public int getActiveCount(){
        activeSystem();
        return activeCount;
    }
    public List<SkillObject> getSkillsActivated(){
        List<SkillObject> skillsAux=new List<SkillObject>();
        foreach (GameObject skill in Skills)
        {
            skillsAux.Add(skill.GetComponent<SkillManager>().getSkill());
        }
        return skillsAux;
    }
}
