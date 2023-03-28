using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private bool    enemyTriggered  = false;
    public  bool    LightOn         = false;
    public  Player  thePlayer;


    void FixedUpdate(){
        if(enemyTriggered){
            if(thePlayer.torchActive == false){
                //When the player doesnt have their torch on do this stuff.//
                //This will be used to deactivate attack scripts as the enemy wont attack players that have their torch off.//
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                enemyTriggered = false;
            }
        }
    }


    public void EnemyTrigger(){
        if(!enemyTriggered){
            ///This is where the enemy ai stuff needs to be put!///
            //This activates the speech bubble, remove when making actual ai script//
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            enemyTriggered = true;
            Debug.Log("HitEnemy");




        }
    }

}
