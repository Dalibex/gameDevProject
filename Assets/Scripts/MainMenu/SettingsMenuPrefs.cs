using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenuPrefs : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private TMPro.TMP_Dropdown graphicalSelect;
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        graphicalSelect.value = PlayerPrefs.GetInt("GraphsValue");
    }

    public void SetVolumePref() {
        PlayerPrefs.SetFloat("MasterVolume", volumeSlider.value);
    }

    public void SetSfxPref() {
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }

    public void SetGraphicalPref() {
        PlayerPrefs.SetInt("GraphsValue", graphicalSelect.value);
    }

}
