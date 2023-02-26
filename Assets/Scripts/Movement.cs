using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D body;
    public int speed;


    // Update is called once per frame
    void Update()
    {

        float Horizontal = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(Horizontal * speed, body.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector3.up * 10, ForceMode2D.Impulse);

        }

    }
}
