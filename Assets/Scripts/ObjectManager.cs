using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll){
        if (coll.CompareTag("Item"))
        {
            FindObjectOfType<Inventory>().setInv(coll);
            
        }
    }
}