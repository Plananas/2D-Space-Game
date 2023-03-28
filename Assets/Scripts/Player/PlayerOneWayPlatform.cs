using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerOneWayPlatform : MonoBehaviour
{
    private GameObject currentOneWayPlatform;

    [SerializeField] private CapsuleCollider2D playerCollider;
    //[SerializeField] private CapsuleCollider2D playerCollider2;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            if(currentOneWayPlatform != null){
                StartCoroutine(DisableCollision());
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Platform")){
            currentOneWayPlatform = collision.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D collision){
            currentOneWayPlatform = null;
    }


    private IEnumerator DisableCollision(){

        TilemapCollider2D platformCollider = currentOneWayPlatform.GetComponent<TilemapCollider2D>();
        Debug.Log("Collision Ignore");
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        //Physics2D.IgnoreCollision(playerCollider2, platformCollider);
        yield return new WaitForSeconds(1f);
        //For some reason this doesnt work as intended//
        Physics2D.IgnoreCollision(playerCollider, playerCollider, false);

        
        //Physics2D.IgnoreCollision(playerCollider2, playerCollider, false);
        Debug.Log("Collisions back");
    }
}
