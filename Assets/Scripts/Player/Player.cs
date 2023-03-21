using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public float sanity;
    public float ammo;

    public int maxHealth = 20;
    public int currentHealth;

    public HealthBar healthBar;

    public Animator PlayerAnimator;
    public GameObject torch;
    public GameObject torchmesh;
    private bool torchActive = true;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(2);
        }
        if(currentHealth <= 0){
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
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    
    void Death(){
        
    }
 
    


     
}

