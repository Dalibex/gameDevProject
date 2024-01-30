using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//Agregamos la libreria de "Audio"
public class SettingsMenu : MonoBehaviour
{
    [Header("Mixers")]
    public AudioMixer audioMixer;
    public AudioMixer effectsMixer;

    //------------------------ SONIDO ------------------------

    //Metodo para cambiar el volumen del mixer de volumen general "audioMixer"
    public void SetMainVolume(float volume) 
    {
        audioMixer.SetFloat("volume", volume);
    }

    //Metodo para cambiar el volumen del mixer de efectos "effectsMixer"
    public void SetEffectsVolume(float volume)
    {
        effectsMixer.SetFloat("volume", volume);
    }


    //------------------------ CONTROL DE QUALITY ------------------------
    public void SetQuality(int qualityIndex) 
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }


    //------------------------ PANTALLA COMPLETA ------------------------
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
