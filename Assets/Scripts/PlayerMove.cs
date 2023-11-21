using System.Net;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed=0.5f;
    public float jumpSpeed=3;
    public SpriteRenderer spriteRenderer;
    Rigidbody2D rb2D;
    public Animator animator;
    private bool canDouble;

    // Start is called before the first frame update
    void Start()
    {
        rb2D=GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        if (Input.GetKeyDown("space")){
            if (CheckGround.isGrounded)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
                //canDouble=true;
            }
            else if (Input.GetKeyDown("space"))
            {
                if (canDouble)
                {
                    rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
                    animator.SetBool("Double",true);
                    canDouble=false;
   
                }   
            }
        }
        if (rb2D.velocity.y<0){
                animator.SetBool("Fall",true);
                if (Input.GetKeyDown("space"))
            {
                if (canDouble)
                {
                    rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
                    animator.SetBool("Double",true);
                    canDouble=false;
   
                }   
            }
            }
            if (rb2D.velocity.y>0){
                animator.SetBool("Fall",false);
            }
            if(CheckGround.isGrounded==true){
                animator.SetBool("Jump",false);
                animator.SetBool("Double",false);
                animator.SetBool("Fall",false);
                canDouble=true;
            }
            if(CheckGround.isGrounded==false){
                animator.SetBool("Jump",true);
                animator.SetBool("Run",false);
            }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d")){
            rb2D.velocity = new Vector2(runSpeed,rb2D.velocity.y);
            spriteRenderer.flipX =false;
            animator.SetBool("Run",true);

        }
        else if (Input.GetKey("a")){
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX=true;
            animator.SetBool("Run",true);
        }
        else {
            rb2D.velocity = new Vector2(0,rb2D.velocity.y);
            animator.SetBool("Run",false);
        }
    }
}
