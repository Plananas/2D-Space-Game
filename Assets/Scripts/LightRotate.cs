using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotate : MonoBehaviour
{
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0f, 0f, rotationSpeed);
    }
}