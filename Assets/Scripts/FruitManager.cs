using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FruitManager : MonoBehaviour
{
    private void Update(){
        AllFruitsCollected();
    }
    public Text levelCleared;
    public void AllFruitsCollected(){
        if (transform.childCount==0)
        {
            Debug.Log("No quedan frutas, Victoria");
            levelCleared.gameObject.SetActive(true);
            //Invoke("ChangeScene",1);
        }
    }

    void ChangeScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
