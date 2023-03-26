using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public  int         health          = 20;
    public  int         sanity;
    public  int         ammo;


    public  HealthBar   healthBar;

    public  Animator    PlayerAnimator;
    public  GameObject  torch;
    public  GameObject  torchmesh;
    public  bool        torchActive     = true;


    void Start()
    {
        healthBar.SetMaxHealth(health);
    }


    void Update()
    {
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
            }
            else{
                torch.SetActive(true);
                torchmesh.SetActive(true);
                torchActive = true;
            }

        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        healthBar.SetHealth(health);
    }
    
    void Death(){
        
    }
 
    


     
}

