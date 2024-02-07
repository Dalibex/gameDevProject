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
            Debug.Log(dataGame.position);
            player.transform.position=dataGame.position;
        }
        else
        {
            Debug.Log("File does not exist");
        }
    }
    private void SaveFile(){
        DataGame newData=new DataGame(){
            position=player.transform.position
        };
        string chainJSON=JsonUtility.ToJson(newData);
        File.WriteAllText(saveFile,chainJSON);
            Debug.Log("File saved");
    }
}
