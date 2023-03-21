using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class FollowAim : MonoBehaviour
{
 
    public GameObject   myPlayer;
    public SpriteRenderer sprite;
    private bool facingRight = true;
    public float rotationZ;

    void FlipSprite(){
        sprite.flipX = !facingRight;
    }


    private void FixedUpdate()
    {
        FlipSprite();
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
 
        difference.Normalize();
 
        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Debug.Log(rotationZ);
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        
        //This will flip the player sprite depending on the direction they face.
        if (rotationZ > -90 && rotationZ < 90){
            facingRight = true;

        }
        else{
            facingRight = false;
        }


        if (rotationZ < -90 || rotationZ > 90)
        {
 
            if(myPlayer.transform.eulerAngles.y == 0)
            {
                
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
 
            } else if (myPlayer.transform.eulerAngles.y == 180) {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);

            }
 
        }
 
    }
 
}