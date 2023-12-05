using System.Net;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed=1;
    public float jumpSpeed=3;
    public SpriteRenderer spriteRenderer;
    Rigidbody2D rb2D;
    public Animator animator;
    private bool canDouble;
    public GameObject wallCollider;
    private bool playerMovement;
    private float wallCounter,horizCounter;
    public float wallStartTime=0.5f;
    public float horizStartTime=0.5f;
    private int direction;
    //public PhysicsMaterial2D terrain;
    private bool horizontalJump,stopMove;
    // Start is called before the first frame update
    void Start()
    {
        rb2D=GetComponent<Rigidbody2D>();
        playerMovement=true;
        wallCounter=wallStartTime;
        horizCounter=horizStartTime;
        direction=1;
        stopMove=false;
        //terrain.friction=0.0045f;
    }
    void Update()
    {      
        if (Input.GetKeyDown("space")) //Jump
        {
            if (CheckGround.isGrounded)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
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
        if (rb2D.velocity.y>0)
        {
            animator.SetBool("Fall",false);
        }
        if(CheckGround.isGrounded==true){
            animator.SetBool("Jump",false);
            animator.SetBool("Double",false);
            animator.SetBool("Fall",false); 
            animator.SetBool("Wall",false);
            CheckWall.isWall=false;               
            canDouble=true;
            playerMovement=true;
            horizCounter=0;
            if (stopMove)
            {
                Invoke("Stoped",0.1f);
            }
        }
        if(CheckGround.isGrounded==false){
            animator.SetBool("Jump",true);
            animator.SetBool("Run",false);
            if (Input.GetKeyDown(KeyCode.LeftShift)) //Air Dash
            {
                playerMovement=false;
                horizCounter=horizStartTime;

            }
        }
        if (CheckWall.isWall==false){
            animator.SetBool("Wall",false);
        }
        if (CheckWall.isWall) //Wall Jump
            {
                horizCounter=0;
                if(Input.GetKey("a")&&Input.GetKey("d")){}else{
                canDouble=false;
                animator.SetBool("Wall",true);
                //rb2D.velocity = new Vector2(rb2D.velocity.x, -0.75f);

                if(Input.GetKey("a"))
                {
                    animator.Play("WallAnimation");
                    if (Input.GetKeyDown("space"))
                    {
                        animator.SetBool("Double",false);
                        wallCounter=wallStartTime;
                        rb2D.velocity = new Vector2(runSpeed, jumpSpeed);
                        playerMovement=false;                                         
                    }
                }
            
                if(Input.GetKey("d"))
                {
                    animator.Play("WallAnimation");
                    if (Input.GetKeyDown("space"))
                    {
                        animator.SetBool("Double",false);
                        wallCounter=wallStartTime;       
                        rb2D.velocity = new Vector2(-runSpeed, jumpSpeed);
                        playerMovement=false;
                    
                    }
                }
            }
            
            }
        if (wallCounter>0)
        {
            wallCounter-=Time.deltaTime;
            if (wallCounter<=0)
            {
                playerMovement=true;
                
                                
            }
        }
        if (horizCounter>0 && !CheckGround.isGrounded && !CheckWall.isWall)
        { 
            animator.SetBool("Fall",false);
            animator.SetBool("Double",false);
            animator.SetBool("Jump",false);
            animator.SetBool("AirDash",true);
            rb2D.velocity=new Vector2(2*direction,0.1f);
            horizCounter-=Time.deltaTime;
            if (horizCounter<=0)
            { 
                playerMovement=true;                              
            }
        }
        if (CheckGround.isGrounded) //Horizontal Jump
        {
            if (Input.GetKey("s"))
            {
                rb2D.velocity = new Vector2(0, rb2D.velocity.y);
                playerMovement=false; 
                animator.SetBool("Run",false);
                if (Input.GetKey("a"))
                {
                    direction=-1;
                    spriteRenderer.flipX=true;
                }else if (Input.GetKey("d"))
                {
                    direction=1;
                    spriteRenderer.flipX=false;
                }
                if(Input.GetKeyDown("space"))
                {
                    stopMove=true;
                    rb2D.velocity = new Vector2(2*runSpeed*direction, jumpSpeed/2);
                    CheckGround.isGrounded=false;
                }//else rb2D.velocity = new Vector2(0, 0);
            }else playerMovement=true;
        }
            
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerMovement)
        {
            if (Input.GetKey("d"))
            {
                direction=1;
                rb2D.velocity = new Vector2(runSpeed,rb2D.velocity.y);
                spriteRenderer.flipX =false;
                animator.SetBool("Run",true);
                wallCollider.transform.position=(new Vector2(transform.position.x,wallCollider.transform.position.y));
            }
            else if (Input.GetKey("a"))
            {
                direction=-1;
                rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
                spriteRenderer.flipX=true;
                wallCollider.transform.position=(new Vector2(transform.position.x-0.16f,wallCollider.transform.position.y));
                animator.SetBool("Run",true);
            }
                else {
                rb2D.velocity = new Vector2(0,rb2D.velocity.y);
                animator.SetBool("Run",false);
                }
        }
    }
    void Stoped(){
        rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        playerMovement=true; 
        stopMove=false;
    }
}
