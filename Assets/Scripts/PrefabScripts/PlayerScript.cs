using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;
    float x, y, moveSpeed = 500f;
    int direction = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), rb.velocity.y, Input.GetAxisRaw("Vertical")) * moveSpeed * Time.deltaTime;

        if (rb.velocity.y > 1f)
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (Input.GetKey(KeyCode.W))
            direction = 1;
        else if (Input.GetKeyUp(KeyCode.W))
            direction = 0;
        if (Input.GetKey(KeyCode.S))
            direction = 2;
        else if (Input.GetKeyUp(KeyCode.S))
            direction = 0;
        if (Input.GetKey(KeyCode.A))
            direction = 3;
        else if (Input.GetKeyUp(KeyCode.A))
            direction = 0;
        if (Input.GetKey(KeyCode.D))
            direction = 4;
        else if (Input.GetKeyUp(KeyCode.D))
            direction = 0;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switch(direction)
            {
                case 1:
                    rb.velocity = Vector3.forward * 500;
                    break;
                case 2:
                    rb.velocity = Vector3.back * 500;
                    break;
                case 3:
                    rb.velocity = Vector3.left * 500;
                    break;
                case 4:
                    rb.velocity = Vector3.right * 500;
                    break;
            }
        }
    }
}
