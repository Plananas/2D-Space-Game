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
    public AudioSource footsteps;
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
        
        //Activating the walking sound effect.
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))){
            //Debug.Log("PlaySound");
            footsteps.UnPause();
        }
        else{
            footsteps.Pause();
        }


        //Jump if we are on the ground.
        if (groundCheck() && Input.GetKeyDown(KeyCode.Space)){

            body.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
           
        }
        

        //Player moving down through the platforms//
        if (Input.GetKeyDown(KeyCode.S)) // Check if the S key is pressed
        {
            Debug.Log("Pressed Down");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Platform")); // Cast a ray down from the player's position
            if (hit.collider != null && hit.collider.CompareTag("Platform")) // Check if the ray hits a platform collider
            {
                CapsuleCollider2D[] colliders = GetComponentsInChildren<CapsuleCollider2D>(); // Get all capsule colliders attached to the player
                foreach (CapsuleCollider2D collider in colliders)
                {
                    Physics2D.IgnoreCollision(collider, hit.collider, true); // Ignore collision between player and platform
                }
                Invoke("ResetCollision", 0.1f); // Re-enable collision after 0.1 seconds
            }
        }
    }

    void ResetCollision()
    {
        CapsuleCollider2D[] colliders = GetComponentsInChildren<CapsuleCollider2D>(); // Get all capsule colliders attached to the player
        foreach (CapsuleCollider2D collider in colliders)
        {
            Physics2D.IgnoreCollision(collider, null, false); // Re-enable collision between player and platform
        }
    }
}
