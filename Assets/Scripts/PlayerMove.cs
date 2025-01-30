using System.Net;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Unity.VisualScripting;
using System.IO;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed=1, jumpSpeed=3;
    public SpriteRenderer spriteRenderer;
    Rigidbody2D rb2D;
    public Animator animator;
    private bool canDouble;
    public GameObject wallCollider;
    private static bool playerMovement;
    private float wallCounter,horizCounter;
    public float wallStartTime=0.5f, horizStartTime=0.5f;
    private int direction,airDashCount;
    public BoxCollider2D boxCollider2D;
    private bool AirActive,WallActive,HorActive,DoubActive;
    public GameObject skillPanel;
    public List<ControlMapping> Controls;
    // Start is called before the first frame update
    void Start()
    {
        rb2D=GetComponent<Rigidbody2D>();
        playerMovement=true;
        wallCounter=wallStartTime;
        horizCounter=horizStartTime;
        direction=1;
        //LoadControls();
    }
    void Update()
    {
        StartCoroutine("getSkillsActive");      
        if (Input.GetKeyDown(InputManager.Instance.GetKey("JumpButton"))) //Jump
        {
            if (CheckGround.isGrounded)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            }
            else if (Input.GetKeyDown(InputManager.Instance.GetKey("JumpButton")))
            {
                if (canDouble&&DoubActive)
                {
                    rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
                    animator.SetBool("Double",true);
                    canDouble=false;
   
                }   
            }
        }
        if (rb2D.velocity.y<0){
                animator.SetBool("Fall",true);
                if (Input.GetKeyDown(InputManager.Instance.GetKey("JumpButton")))
            {
                if (canDouble&&DoubActive)
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
            airDashCount=1;
        }
        if(CheckGround.isGrounded==false){
            animator.SetBool("Jump",true);
            animator.SetBool("Run",false);
            //Air Dash
            if (airDashCount>0&&Input.GetKeyDown(KeyCode.LeftShift)&&AirActive) 
            {
                if (!CheckWall.isWall)
                {
                playerMovement=false;
                horizCounter=horizStartTime;
                rb2D.velocity=new Vector2(rb2D.velocity.x,0.2f);
                airDashCount--;
                }else
                {
                    horizCounter=0;
                }
            }
        }
        if (CheckWall.isWall==false){
            animator.SetBool("Wall",false);
        }
        if (CheckWall.isWall&&WallActive) //Wall Jump
            {
                horizCounter=0;
                if(Input.GetKey(InputManager.Instance.GetKey("MoveLeftButton"))&&Input.GetKey(InputManager.Instance.GetKey("MoveRightButton"))){}else{
                canDouble=false;
                animator.SetBool("Wall",true);
                if(Input.GetKey(InputManager.Instance.GetKey("MoveLeftButton")))
                {
                    animator.Play("WallAnimation");
                    if (Input.GetKeyDown(InputManager.Instance.GetKey("JumpButton")))
                    {
                        animator.SetBool("Double",false);
                        wallCounter=wallStartTime;
                        rb2D.velocity = new Vector2(runSpeed, jumpSpeed);
                        playerMovement=false;                                         
                    }
                }
            
                if(Input.GetKey(InputManager.Instance.GetKey("MoveRightButton")))
                {
                    animator.Play("WallAnimation");
                    if (Input.GetKeyDown(InputManager.Instance.GetKey("JumpButton")))
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
            //animator.SetBool("AirDash",true);
            rb2D.velocity=new Vector2(2*direction,0.1f);
            horizCounter-=Time.deltaTime;
            if (horizCounter<=0)
            { 
                playerMovement=true;                              
            }
        }
        if (CheckGround.isGrounded&&HorActive) //Horizontal Jump
        {
            if (Input.GetKey(InputManager.Instance.GetKey("GoDownButton")))//platform ojo
            {
                rb2D.velocity = new Vector2(0, rb2D.velocity.y);
                playerMovement=false; 
                animator.SetBool("Run",false);
                if (Input.GetKey(InputManager.Instance.GetKey("MoveLeftButton")))
                {
                    direction=-1;
                    spriteRenderer.flipX=true;
                }else if (Input.GetKey(InputManager.Instance.GetKey("MoveRightButton")))
                {
                    direction=1;
                    spriteRenderer.flipX=false;
                }
                if(Input.GetKeyDown(InputManager.Instance.GetKey("JumpButton")))
                {
                    rb2D.velocity = new Vector2(2*runSpeed*direction, jumpSpeed/2);
                    CheckGround.isGrounded=false;
                }
            }else playerMovement=true;
        }   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerMovement)
        {
            if (Input.GetKey(InputManager.Instance.GetKey("MoveRightButton")))
            {
                direction=1;
                rb2D.velocity = new Vector2(runSpeed,rb2D.velocity.y);
                spriteRenderer.flipX =false;
                animator.SetBool("Run",true);
                wallCollider.transform.position=(new Vector2(transform.position.x,wallCollider.transform.position.y));
            }
            else if (Input.GetKey(InputManager.Instance.GetKey("MoveLeftButton")))
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
    public void  Bounce(){
        rb2D.velocity= new Vector2(0,2);
        boxCollider2D.isTrigger=true;
        CheckGround.isGrounded=false;
        CheckWall.isWall=false;
        spriteRenderer.sortingOrder=3;
        playerMovement=false;
    }
    public static void setPlayerMovement(bool Bool){
        playerMovement=Bool;
    }
    private IEnumerator getSkillsActive(){
        AirActive=skillPanel.transform.GetChild(0).transform.GetChild(3).gameObject.activeSelf;
        WallActive=skillPanel.transform.GetChild(1).transform.GetChild(3).gameObject.activeSelf;
        HorActive=skillPanel.transform.GetChild(2).transform.GetChild(3).gameObject.activeSelf;
        DoubActive=skillPanel.transform.GetChild(3).transform.GetChild(3).gameObject.activeSelf;
        yield return new WaitForSeconds(0.2f);
    }
}
