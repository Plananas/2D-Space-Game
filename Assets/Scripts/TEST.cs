using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TEST : MonoBehaviour
{
    public int sceneBuildIndex;

    public void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");
        
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            print("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
