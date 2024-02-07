using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    private bool ActivatePanel;
    public GameObject SkillPanel;
    public List<GameObject> Skills=new List<GameObject>();
    private Queue<GameObject> activatedSkills=new Queue<GameObject>();
    private List<GameObject> activatedSkills2=new List<GameObject>();
    private int activeCount=0,active0=0,active1=0,active2=0,active3=0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ActivatePanel)
        {
            SkillPanel.SetActive(true);
            PlayerMove.setPlayerMovement(false);
        }else
        {
            SkillPanel.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ActivatePanel=!ActivatePanel;
        }
        //Debug.Log(activatedSkills);
        //activeSystem();
        //activeSystem2();
        provisionalActiveSystem();
        Debug.Log(getActiveCount());
    }
    private void activeSystem2(){
        if (activatedSkills2.Count>2)
        {
            activatedSkills2.RemoveAt(0);
            //activatedSkills2[0]=activatedSkills2[1];
        }else{
            foreach (GameObject skill in Skills)
            {
                if (skill.transform.GetChild(3).gameObject.activeSelf)
                {
                    activatedSkills2.Add(skill);
                }
            }
        }
    }
    private void activeSystem(){
        foreach (GameObject skill in Skills)
            {
                if (skill.transform.GetChild(3).gameObject.activeSelf)
                {
                    activatedSkills.Enqueue(skill);
                }
            }
    }
    private void provisionalActiveSystem(){
        /*foreach (GameObject skill in Skills){
            if (skill.transform.GetChild(3).gameObject.activeSelf)
                {
                    activeCount++;
                }
            }*/
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
}
