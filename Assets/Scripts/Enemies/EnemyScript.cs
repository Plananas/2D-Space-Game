using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("torch")){
            Debug.Log("torch collided with enemy.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
