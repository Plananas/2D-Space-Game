using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public SpriteRenderer sprite;


    private bool facingRight = true;
    //Keeping the flip code separate so it can be attached only to the sprites.
    void Update()
    {
        /*
        float Horizontal = Input.GetAxisRaw("Horizontal");
                //Flip the player sprite.
        if (Horizontal > 0 && !facingRight)
        {
            FlipSprite();
        }
        if (Horizontal < 0 && facingRight)
        {
            FlipSprite();
        } 
        */
    }

    
    void FlipSprite(){
        //Vector3 currentScale = gameObject.transform.localScale;
        //currentScale.x *= -1;
        //gameObject.transform.localScale = currentScale;
        sprite.flipX = !sprite.flipX;
        facingRight = !facingRight;
    }
}
