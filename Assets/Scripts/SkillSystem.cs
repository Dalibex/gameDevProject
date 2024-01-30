using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    private bool ActivatePanel;
    public GameObject SkillPanel;
    public List<GameObject> Skills=new List<GameObject>();
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
    }
}
