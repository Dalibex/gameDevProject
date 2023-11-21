using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed=2;
    public float jumpSpeed=3;
    public SpriteRenderer spriteRenderer;
    Rigidbody2D rb2D;
    public Animator animator;
    private int jumpCounter=1;

    // Start is called before the first frame update
    void Start()
    {
        rb2D=GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d")){
            rb2D.velocity = new Vector2(runSpeed,rb2D.velocity.y);
            spriteRenderer.flipX =false;
            animator.SetBool("Run",true);
            animator.SetBool("Double",false);
            animator.SetBool("Jump",false);

        }
        else if (Input.GetKey("a")){
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX=true;
            animator.SetBool("Run",true);
            animator.SetBool("Double",false);
            animator.SetBool("Jump",false);
        }
        else {
            rb2D.velocity = new Vector2(0,rb2D.velocity.y);
            animator.SetBool("Run",false);
            animator.SetBool("Jump",false);
            animator.SetBool("Double",false);
        }
        if (Input.GetKey("space") && CheckGround.isGrounded){
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            animator.SetBool("Run",false);
           


        }
        
        if(CheckGround.isGrounded==false){
            animator.SetBool("Jump",true);
            animator.SetBool("Run",false);

            /*if (rb2D.velocity.y<0){
                animator.SetBool("Fall",true);
                animator.SetBool("Jump",false);
                animator.SetBool("Run",false);
                animator.SetBool("Double",false);
            }*/
            
            if (Input.GetKey("w") && jumpCounter==1)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
                animator.SetBool("Double",true);
                animator.SetBool("Run",false);
                animator.SetBool("Fall",false);
                jumpCounter--;
            }

        }
        if (CheckGround.isGrounded ==true){
            animator.SetBool("Jump",false);
            animator.SetBool("Double",false);
            jumpCounter=1;
        }
        
    }
}
