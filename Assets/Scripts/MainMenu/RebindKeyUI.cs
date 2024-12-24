using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RebindKeyUI : MonoBehaviour
{
    public string actionName;
    public TextMeshProUGUI keyText;
    private bool isRebinding = false;

    public void Start()
    {

    }

    private void Update()
    {
        if (isRebinding)
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(key))
                    {
                        InputManager.Instance.SetKey(actionName, key);
                        keyText.text = key.ToString();
                        InputManager.Instance.SaveControlsToJSON();
                        isRebinding = false;

                        Debug.Log($"Action '{actionName}' reassigned to key '{key}'");
                        return;
                    }
                }
            }
        }
    }

    public void UpdateKeyText(string actionN)
    {
        //KeyCode key = InputManager.Instance.GetKey(actionN);
        keyText.text = actionN;
    }

    public void StartRebinding()
    {
        if (!isRebinding)
        {
            isRebinding = true;
            keyText.text = "Press a Key...";
        }
    }
}
