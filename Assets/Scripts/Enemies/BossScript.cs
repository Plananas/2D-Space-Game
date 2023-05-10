using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{


    public GameObject[] doors;



    // Update is called once per frame
    void Update()
    {
        
        int randomnumber    = Random.Range(0, 1500);  // creates a number between 1 and 12
        int randomDoor      = Random.Range(0, 5);

        if(randomnumber == 12.0f){

            if (doors[randomDoor].active){
                doors[randomDoor].SetActive(false);
            }
            else{
                doors[randomDoor].SetActive(true);
            }

        }

    }
}
