using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private bool isBlocked,isSelected,isActive;
    [SerializeField] private GameObject Block,Select,Active;
    public SkillObject skill;

    // Update is called once per frame
    void Update()
    {
        if (isBlocked)
        {
            Block.SetActive(true);
        }else{
            Block.SetActive(false);
        }
        if (isSelected)
        {
            Select.SetActive(true);
        }else{
            Select.SetActive(false);
        }
        if (!isBlocked&&isActive)
        {
            Active.SetActive(true);
        }else{
            Active.SetActive(false);
        }
    }
    public void clickin(){
        if(isSelected){
            if (!isActive&&!isBlocked&&(FindObjectOfType<SkillSystem>().getActiveCount()!=2))
            {
                isActive=true;
                skill.isActive=true;
            }else{
                isActive=false;
                skill.isActive=false;
            }
        }
    }
    public void MouseOver(){
        isSelected=true;
    }
    public void MouseExit(){
        isSelected=false;
    }
    public SkillObject getSkill(){
        return skill;
    }
    public void setIsBlocked(bool value){
        isBlocked=value;
    }
    public void setIsActive(bool value){
        isActive=value;
    }
}
