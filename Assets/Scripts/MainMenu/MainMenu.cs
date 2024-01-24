using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Para las escenas usamos la libreria de SceneManagement que viene con
"SceneManager." */
public class MainMenu : MonoBehaviour
{
    private Animator transitionAnimator;
    [SerializeField] private float transitionTime = 1f;
    private GameObject image;

    void Start()
    {
        //Recogemos el animator (SUPUESTAMENTE ESTO DA ERROR, DEBERIA ENCONTRAR EL COMPONENTE ANIMATOR DE FADEEFFECT!!!!!!!!!)
        transitionAnimator = GetComponentInChildren<Animator>();

        //Buscamos imagen y la desactivamos tras el fade de inicio en la corutina
        image = GameObject.FindWithTag("Fade");
        StartCoroutine(disableFadeEffect());
    }

    //Cambiar escena de pantalla de menu principal al juego
    public void PlayGame() {
        /*Llamamos a este método pulsando el botón, cogemos el siguiente index 
        y llamamos a la corutina para iniciar la transición*/
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine (SceneLoad(nextSceneIndex));
    }

    public IEnumerator disableFadeEffect()
    {
        yield return new WaitForSeconds(transitionTime);
        image.SetActive(false);
    }

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