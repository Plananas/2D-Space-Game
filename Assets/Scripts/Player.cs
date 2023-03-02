using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public float sanity;
    public float ammo;
    [SerializeField] CheckLight checkLight;
    
    void Update(){
        checkLight.SetOrigin(transform.position);
    }
     
}
