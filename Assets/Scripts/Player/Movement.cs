using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D  body;
    public Transform    groundChecker;
    public Transform    roofChecker;
    public LayerMask    groundlayer;
    public int          speed;
    public AudioSource  footsteps;
    public Animator     animator;
    public int          jumpForce;

    public bool        Falling;

    public  CapsuleCollider2D    StandingCollider1;
    public  CapsuleCollider2D    StandingCollider2;
    public  CapsuleCollider2D    CrouchingCollider;


    

    //Check if player is touching the ground before they can jump.
    private bool groundCheck(){
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundChecker.position, 0.2f, groundlayer);
        if(colliders.Length>0){
            return true;
        }
        return false;
    } 
    //Check if the player is touching the roof while crouching.
    private bool roofCheck(){
        Collider2D[] colliders = Physics2D.OverlapCircleAll(roofChecker.position, 0.2f, groundlayer);
        if(colliders.Length>0){
            return true;
        }
        return false;
    } 


    void Update()
    {
        groundCheck();
        //Movement Scripts//
        float Horizontal = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(Horizontal * speed, body.velocity.y);

        //Sets animator up for walking animation.
        animator.SetFloat("Speed", Math.Abs(body.velocity.x));
        
        //Activating the walking sound effect.
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))){
            //Debug.Log("PlaySound");
            footsteps.UnPause();
        }
        else{
            footsteps.Pause();
        }


        //Jump if we are on the ground.
        if ((groundCheck() && Input.GetKeyDown(KeyCode.Space)) && !Input.GetKey(KeyCode.S)){

            body.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
           
        }
        

        //Player Crouching//
        if(Input.GetKey(KeyCode.C)){

            CrouchingCollider.enabled = true;
            StandingCollider1.enabled = false;
            StandingCollider2.enabled = false;
            animator.SetBool("IsCrouching", true);

            ///NEED TO CHANGE LOCATION OF TORCH OBJECT IN THE GAME!///
        }
        else if(roofCheck() == false){
            CrouchingCollider.enabled = false;
            StandingCollider1.enabled = true;
            StandingCollider2.enabled = true;            
            animator.SetBool("IsCrouching", false);
        }


        //Player Falling//
        //Does not work as intended this will need some work on!
        /*
        if (body.velocity.y < 1)
        {
            Falling = true;
            animator.SetBool("IsFalling", true);
        }
        else
        {
            animator.SetBool("IsFalling", false);
            Falling = false;
        }
        */

    }

    void ResetCollision()
    {

        //Physics2D.IgnoreCollision(collider, null, false); // Re-enable collision between player and platform

    }
}
