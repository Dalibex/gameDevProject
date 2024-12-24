using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private bool isBlocked,isSelected,isActive;
    [SerializeField] private GameObject Block,Select,Active;
    private int activeCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        if (!isBlocked&&isActive&&(FindObjectOfType<SkillSystem>().getActiveCount()<=2))
        {
            Active.SetActive(true);
        }else{
            Active.SetActive(false);
            if ((FindObjectOfType<SkillSystem>().getActiveCount()>2))
            {
                Active.SetActive(false);
            }
        }
    }
    public void clickin(){
        if(isSelected){
            if (!isActive&&!isBlocked&&(FindObjectOfType<SkillSystem>().getActiveCount()!=2))
            {
                isActive=true;
            }else{
                isActive=false;
            }
        }
    }
    public void MouseOver(){
        isSelected=true;
        Debug.Log("Mouse On");
    }
    public void MouseExit(){
        isSelected=false;
    }
    public bool getisActive(){
        return isActive;
    }
}
