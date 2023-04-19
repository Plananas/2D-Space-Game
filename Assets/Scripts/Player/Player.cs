using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Player : MonoBehaviour
{
    public  int          health;
    public  float        battery;
    public  float        sanity;
    public  float        ammo; 

    public  HealthBar    healthBar;
    public  BatteryBar   batteryBar;

    public  Animator     PlayerAnimator;
    public  GameObject   torch;
    public  GameObject   torchmesh;

    public  bool         torchActive = true;

    public AudioSource torchOn;
    public AudioSource torchOff;


    private bool         dead = false;
    public  Movement     playerMovement;


    void Start()
    {    

        healthBar.SetHealth(health);
        batteryBar.SetBattery(battery);

    }

    void Update()
    {
        if(!dead){
            //Updates the bars
            batteryBar.SetBattery(battery);
            healthBar.SetHealth(health);
            
            //This will neeed to change to trigger if an enemy makes contact with us//
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(2);
            }
            if(health <= 0){
                Death();
            }
            //When player presses T, toggle torch.
            if (Input.GetKeyDown(KeyCode.T) && (battery > 0)){
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
            //Turns the torch off when it runs out of power.
            if(battery <= 0){
                torchActive = false;
                torch.SetActive(false);
                torchmesh.SetActive(false);
                torchOff.Play(0);
            }
            //Constantly lower the battery when the torch is on.
            if(torchActive){
                battery -= 0.5f * Time.deltaTime;
            }

            //Decreases the sanity when the torch is not on//
            if(!torchActive){
                sanity -= 0.5f * Time.deltaTime;

            }
        }

    }

    void TakeDamage(int damage)
    {
        health -= damage;
        
    } 
    void UseBattery(int UseBattery)
    {
        battery -= UseBattery;
        
    }

    //This will play the death animation//
    void Death(){
        //Deactivate the player movement//
        playerMovement.enabled = false;
        dead = true;

    }
}

