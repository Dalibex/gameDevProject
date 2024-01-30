using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.ComponentModel;
using Vector3 = UnityEngine.Vector3;

public class Inventory : MonoBehaviour
{
    public List<GameObject> Bag = new List<GameObject>();
    public GameObject inv;
    private bool Activar_inv;
    //private Vector3 selectedPos,slot0Pos,slot1Pos,slot2Pos,slot3Pos;
    //private Transform Inv;
    //private float spaceItems=237f;
    // Start is called before the first frame update
    void Start()
    {
        /*Inv=transform.GetChild(0);
        selectedPos=Inv.transform.GetChild(0).position;
        slot0Pos=Inv.transform.GetChild(1).position;
        slot1Pos=Inv.transform.GetChild(2).position;
        slot2Pos=Inv.transform.GetChild(3).position;
        slot3Pos=Inv.transform.GetChild(4).position;
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Activar_inv){
            inv.SetActive(true);
            PlayerMove.setPlayerMovement(false);
            //navegation();
        }
        else {
            inv.SetActive(false);
            }
        if (Input.GetKeyDown(KeyCode.Return)){
            setInvBool();
            Debug.Log("activao");
        }
    }
    public void setInvBool(){
        Activar_inv =!Activar_inv;
    }
    public void setInv(Collider2D coll){
        for (int i = 0; i < Bag.Count; i++)
            {
                if (Bag[i].GetComponent<Image>().enabled==false)
                {
                    Bag[i].GetComponent<Image>().enabled=true;
                    Bag[i].GetComponent<Image>().sprite=coll.GetComponent<SpriteRenderer>().sprite;
                    break;
                }
            }
    }
    /*private void navegation(){
        if(Input.GetKeyDown("d")){
            transform.GetChild(0).transform.GetChild(0).position=new Vector3(getXTransform()+spaceItems,getYTransform(),0);
        }else{if (getXTransform()>slot3Pos.x+50)
                {
                    transform.GetChild(0).transform.GetChild(0).position=slot0Pos;
                }
            }
        if(Input.GetKeyDown("a")){
            transform.GetChild(0).transform.GetChild(0).position=new Vector3(getXTransform()-spaceItems,getYTransform(),0);
        }else{if (getXTransform()<slot0Pos.x)
                {
                    transform.GetChild(0).transform.GetChild(0).position=slot3Pos;
                }
            }
    }
    private float getXTransform(){

        return transform.GetChild(0).transform.GetChild(0).position.x;
    }
    private float getYTransform(){

        return transform.GetChild(0).transform.GetChild(0).position.y;
    }*/
}
