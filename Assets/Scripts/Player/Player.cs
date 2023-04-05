using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Player : MonoBehaviour
{
    public  int          health;
    public  int          stamina;
    public  float        sanity;
    public  float        ammo;


    public  HealthBar    healthBar;
    public  StaminaBar   staminaBar;

    public  Animator     PlayerAnimator;
    public  GameObject   torch;
    public  GameObject   torchmesh;

    public  bool         torchActive = true;

    public AudioSource torchOn;
    public AudioSource torchOff;

    void Start()
    {    


        healthBar.SetHealth(health);
        staminaBar.SetStamina(stamina);

    }

    void Update()
    {
        

        //This will neeed to change to trigger if an enemy makes contact with us//
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(2);
        }
        if(health <= 0){
            Death();
        }
        //When player presses T, toggle torch.
        if (Input.GetKeyDown(KeyCode.T)){
            if(torchActive){
                torch.SetActive(false);
                torchmesh.SetActive(false);
                torchActive = false;
                torchOff.Play(0);
                
            }
            else{
                torch.SetActive(true);
                torchmesh.SetActive(true);
                torchActive = true;
                
                torchOn.Play(0);

            }
        }

        //We will do this when running//
        //running not implemented just yet//
        if (Input.GetKeyDown(KeyCode.M))
        {
            UseStamina(2);
        }

        //Decreases the sanity when the torch is not on//
        if(!torchActive){
            sanity -= 0.5f * Time.deltaTime;

        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
    }

    //This will play the death animation//
    void Death(){
        
    }
 
    void UseStamina(int UseStamina)
    {
        stamina -= UseStamina;

        staminaBar.SetStamina(stamina);
    }

     
}

