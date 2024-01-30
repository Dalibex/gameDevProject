using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private bool isBlocked,isSelected,isActive;
    [SerializeField] private GameObject Block,Select,Active;
    
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
        if (!isBlocked&&isActive)
        {
            Active.SetActive(true);
        }else{
            Active.SetActive(false);
        }
    }
    public void clickin(){
        if(isSelected){
            if (!isActive)
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
}
