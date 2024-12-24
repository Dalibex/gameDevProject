using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ControlMapping
{
    public string actionName;
    public string key;
}

[System.Serializable]
public class ControlSettings
{
    public List<ControlMapping> controls = new List<ControlMapping>();
}
