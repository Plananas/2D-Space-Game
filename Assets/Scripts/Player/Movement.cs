using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D body;
    public Transform  groundChecker;
    public LayerMask groundlayer;
    public int speed;
    
    public Animator animator;
    public int jumpForce;

    //Check if player is touching the ground before they can jump.
    private bool groundCheck(){
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundChecker.position, 0.2f, groundlayer);
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



        //Jump if we are on the ground.
        if (groundCheck() && Input.GetKeyDown(KeyCode.Space)){

            body.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
           
        }
    }
}
