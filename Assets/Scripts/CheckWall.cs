using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckWall : MonoBehaviour
{
   public static bool isWall;

   private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Ground")&&CheckGround.isGrounded==false)
        {
            isWall =true;         
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.CompareTag("Ground"))
        {
            isWall =false;
        }
    }
}
