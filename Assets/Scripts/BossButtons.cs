using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossButtons : MonoBehaviour
{
    private bool buttonPressed = false;
    public TextModify textscript;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            if(!buttonPressed){
                Debug.Log("Player entered the collider.");
                buttonPressed = true;
                textscript.Increment();
            }

        }
    }

/*
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && !buttonPressed)
            {
                buttonPressed = true;
                Debug.Log("Button pressed!");
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the collider.");
        }
    }
    */

}
