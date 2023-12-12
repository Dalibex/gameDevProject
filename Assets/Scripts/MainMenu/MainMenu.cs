using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Para las escenas usamos la libreria de SceneManagement que viene con
"SceneManager." */
public class MainMenu : MonoBehaviour
{
    //Cambiar escena de pantalla de menu principal al juego (SOLO FUNCIONA PARA ESTE CASO!!)
    public void PlayGame() {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex); 
    }

    //Cerrar el juego
    public void QuitGame() {
        Application.Quit();
    }
}
