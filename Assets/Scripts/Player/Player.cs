using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public float stamina;
    public float sanity;
    public float ammo;

    public int maxHealth = 20;
    public int currentHealth;
    public int maxStamina = 20;
    public int currentStamina; 

    public HealthBar healthBar;
    public StaminaBar staminaBar;

    public Animator PlayerAnimator;
    public GameObject torch;
    public GameObject torchmesh;

    private bool torchActive = true;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
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
        if (Input.GetKeyDown(KeyCode.M))
        {
            UseStamina(2);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    
    void Death(){
        
    }
 
    void UseStamina(int UseStamina)
    {
        currentStamina -= UseStamina;

        staminaBar.SetStamina(currentStamina);
    }
    


     
}

