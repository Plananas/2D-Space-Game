using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRetical : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    void Reticle()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
    }

    // Update is called once per frame
    void Update()
    {
        Reticle();
    }
}
