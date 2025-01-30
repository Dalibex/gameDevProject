using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsInGame : MonoBehaviour
{
    private bool Panel;
    public GameObject options;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&& !FindFirstObjectByType<SkillSystem>().ActivatePanel) {
            Panel =! Panel;
            Time.timeScale = Panel ? 0 : 1;
        }
        options.SetActive(Panel);
    }

    public void close() {
        Panel = false;
        Time.timeScale = 1;
    }
    public void returnMainMenu() {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
