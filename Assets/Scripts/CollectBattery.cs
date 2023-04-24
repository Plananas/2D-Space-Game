using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBattery : MonoBehaviour
{
    public AudioSource batterynoise;



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            // Add item collection logic here
            Player player = GameObject.Find("Player").GetComponent<Player>(); // Find the player GameObject and get the Player script
            if(player.battery < 20){
                for(int x = 0; x < 10; x++){
                    //This is for health but we can change it to be any of the other player stats.

                    if(player.battery < 20){
                        player.battery += 1; // Add 5 health to the player
                    }
                }
                batterynoise.Play(0);

                Debug.Log("Player has collected battery pack!");
                Destroy(gameObject); // Destroy the item
            }

        }
    }
}
