using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using System;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public List<ControlMapping> Controls = new List<ControlMapping>();
    private string filePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //filePath = Path.Combine(Application.persistentDataPath, "controls.json");    
        filePath = "Assets/data/controls.json";    
    }

    public void Start() {
        LoadControlsFromJSON();
    }

    public void SaveControlsToJSON()
    {
        ControlSettings settings = new ControlSettings { controls = Controls };
        string json = JsonUtility.ToJson(settings, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Controls saved to: " + filePath);
    }

    public void LoadControlsFromJSON()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            ControlSettings settings = JsonUtility.FromJson<ControlSettings>(json);
            Controls = settings.controls;

            Debug.Log("Controls loaded from: " + filePath);
        }
        else
        {
            Debug.LogWarning("No controls file found. Using default controls.");
            Controls.Add(new ControlMapping { actionName = "MoveLeftButton", key = "A" });
            Controls.Add(new ControlMapping { actionName = "MoveRightButton", key = "D" });
            Controls.Add(new ControlMapping { actionName = "GoDownButton", key = "S" });
            Controls.Add(new ControlMapping { actionName = "JumpButton", key = "Space" });
            Controls.Add(new ControlMapping { actionName = "SkillPanelButton", key = "F" });

            SaveControlsToJSON();
        }
    }

    public KeyCode GetKey(string actionName)
    {
        foreach (var control in Controls)
        {
            if (control.actionName == actionName)
            {
                //Debug.Log($"Trying to convert '{control.key}' to KeyCode for action '{actionName}'");

                KeyCode keyCode;
                if (System.Enum.TryParse(control.key, out keyCode))
                {
                    return keyCode;
                }
                else
                {
                    Debug.LogWarning($"Failed to convert '{control.key}' to KeyCode for action '{actionName}'");
                    return KeyCode.None;
                }
            }
        }
        return KeyCode.None;
    }

    public void SetKey(string actionName, KeyCode newKey)
    {
        foreach (var control in Controls)
        {
            if (control.actionName == actionName)
            {
                control.key = newKey.ToString();
                SaveControlsToJSON();
                return;
            }
        }
    }
}
