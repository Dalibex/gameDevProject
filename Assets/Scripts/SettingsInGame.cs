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
        }
        options.SetActive(aj);
    }

    public void close() {
        aj = false;
    }
}
