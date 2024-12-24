using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataController : MonoBehaviour
{
    public GameObject player;
    public string saveFile;
    public DataGame dataGame=new DataGame();
    public List<SkillObject> skillsActivated= new List<SkillObject>();
    private void Awake(){
        saveFile=Application.dataPath+"/Data/dataGame.json";
        player= GameObject.FindGameObjectWithTag("Player");        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F5)){
            SaveFile();
        }
        if(Input.GetKeyDown(KeyCode.F6)){
            LoadData();
        }
    }
    private void LoadData(){
        if (File.Exists(saveFile))
        {
            string contenido=File.ReadAllText(saveFile);
            dataGame=JsonUtility.FromJson<DataGame>(contenido);
            Debug.Log("loaded");
            player.transform.position=dataGame.position;
            loadSkills(dataGame.skills);
        }
        else
        {
            Debug.Log("File does not exist");
        }
    }
    private void SaveFile(){
        DataGame newData=new DataGame(){
            position=player.transform.position,
            skills=FindObjectOfType<SkillSystem>().getSkillsActivated()
        };
        string chainJSON=JsonUtility.ToJson(newData);
        File.WriteAllText(saveFile,chainJSON);
            Debug.Log("File saved");
    }
    private void loadSkills(List<SkillObject> skills){
        foreach (SkillObject skill in skills)
        {
            foreach(GameObject skillGame in FindObjectOfType<SkillSystem>().Skills)
            {
                if (skill.id==skillGame.GetComponent<SkillManager>().skill.id)
                {
                    skillGame.GetComponent<SkillManager>().skill=skill;
                    skillGame.GetComponent<SkillManager>().setIsActive(skill.isActive);
                    skillGame.GetComponent<SkillManager>().setIsBlocked(skill.isLocked);
                }
            }
        }
    }
}
