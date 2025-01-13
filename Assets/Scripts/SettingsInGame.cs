using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsInGame : MonoBehaviour
{
    private bool aj;
    public GameObject options;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            aj =! aj;
            Time.timeScale = aj ? 0 : 1;
        }
        options.SetActive(aj);
    }

    public void close() {
        aj = false;
        Time.timeScale = 1;
    }
    public void returnMainMenu() {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
