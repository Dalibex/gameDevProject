using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Para las escenas usamos la libreria de SceneManagement que viene con
"SceneManager." */
public class MainMen : MonoBehaviour
{
    private Animator transitionAnimator;
    [SerializeField] private float transitionTime = 1f;
    private GameObject image;

    void Start()
    {
        //Recogemos el animator dentro de los hijos del objeto "MainMenu", fadeEffect
        transitionAnimator = GetComponentInChildren<Animator>();

        //Buscamos imagen y la desactivamos tras el fade de inicio en la corutina
        image = GameObject.FindWithTag("Fade");
        StartCoroutine(disableFadeEffect());
    }

    //Cambiar escena de pantalla de menu principal al juego
    public void PlayGame() {
        /*Llamamos a este método pulsando el botón "empezar", cogemos el siguiente index 
        y llamamos a la corutina para iniciar la transición*/
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine (SceneLoad(nextSceneIndex));
    }

    //Desactiva la imagen de fade para no dar problemas al estar superpuesta al canvas tras esperar el tiempo de transicion
    public IEnumerator disableFadeEffect()
    {
        yield return new WaitForSeconds(transitionTime);
        image.SetActive(false);
    }

    //Cargamos la escena, activamos la imagen, disparamos el trigger para la animacion de transicion y cargamos escena
    public IEnumerator SceneLoad(int sceneIndex) 
    {
        image.SetActive(true);
        //Disparar trigger para reproducir la animación de FadeIn
        transitionAnimator.SetTrigger("StartTransition");
        //Esperamos un segundo y cargamos la escena con el valor pasado por parámetro
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }

    //Cerrar el juego
    public void QuitGame() {
        Application.Quit();
    }
}