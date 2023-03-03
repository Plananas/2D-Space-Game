using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public KeyCode doorHandleOpen;
    public KeyCode doorHandleClose;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(doorHandleOpen))
        {
            transform.position = new Vector3(0, 3, 0);
        }
        if (Input.GetKeyDown(doorHandleClose))
        {
            transform.position = new Vector3(0, 0, 0);
        }

    }
}
