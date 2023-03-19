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
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    
    void Death(){
        
    }
 
    


     
}

