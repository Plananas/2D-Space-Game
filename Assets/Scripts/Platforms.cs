using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Platforms : MonoBehaviour
{
    private Collider2D _collider;

    private bool _playerOnPlatform;

    // Start is called before the first frame update
    private void Start()
    {
        _collider = GetComponent<TilemapCollider2D>();     
    }
    private void Update(){

        //Player moving down through the platforms//
        if ((Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.S)) && _playerOnPlatform) // Check if the S key is pressed
        {
            Debug.Log("Go Through Platform");
            _collider.enabled = false;
            StartCoroutine(EnableCollider());
            
        }

    }


    private IEnumerator EnableCollider(){

        yield return new WaitForSeconds(0.5f);
        _collider.enabled = true;
    }


    private void SetPlayerOnPlatform(Collision2D other, bool value){

        var player = other.gameObject.CompareTag("Player");
        if(player != false){
            Debug.Log("Player On Platform");
            _playerOnPlatform = value;
        }
    }



    private void OnCollisionEnter2D(Collision2D other){
        //Debug.Log("Player On Platform");
        SetPlayerOnPlatform(other, true);
    }

    private void OnCollisionExit2D(Collision2D other){

        SetPlayerOnPlatform(other, true);
    }
}
