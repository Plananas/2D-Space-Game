using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHealth : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            // Add item collection logic here
            Player player = GameObject.Find("Player").GetComponent<Player>(); // Find the player GameObject and get the Player script
            if(player.health < 20){
                for(int x = 0; x < 5; x++){
                    //This is for health but we can change it to be any of the other player stats.

                    if(player.health < 20){
                        player.health += 1; // Add 5 health to the player
                    }
                }
                Debug.Log("Player has collected health pack!");
                Destroy(gameObject); // Destroy the item
            }

        }
    }
}