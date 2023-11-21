using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isGrounded;
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Ground") || collision.CompareTag("Platform"))
        {
            isGrounded =true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.CompareTag("Ground") || collision.CompareTag("Platform"))
        {
            isGrounded =false;
        }
    }
}
