using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRetical : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    void Reticle()
    {
        var mousePos1 = Input.mousePosition;
        mousePos1.z = 7; // select distance = 10 units from the camera

        Vector3 mousePos = mainCamera.ScreenToWorldPoint(mousePos1);
        
        mousePos.z = 0f;
        transform.position = mousePos;
    }

    // Update is called once per frame
    void Update()
    {
        Reticle();
    }
}
