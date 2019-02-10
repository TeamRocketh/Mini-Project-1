using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    Rigidbody boxRb;
    public int BoxHP=2;
    public Vector3 boxSpawnLocation;
    bool isMoving;
    public float speed;
    Vector3 moveDir;

    void Start()
    {
        boxSpawnLocation = transform.position;
        boxRb = GetComponent<Rigidbody>();
        isMoving = false;
    }
    
    void Update()
    {
        if (boxRb.velocity.x == 0 && boxRb.velocity.z == 0)
        {
            isMoving = false;
        }
        if (boxRb.velocity == Vector3.zero)
        {
            boxRb.isKinematic = true;
        }
        if(isMoving)
        {
            boxRb.velocity =  moveDir * speed;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag=="Player")
        {
            if (PlayerController.isDashing)
            {
                BoxHP--;
                moveDir = col.gameObject.GetComponent<PlayerController>().dir;
                boxRb.isKinematic = false;
                boxRb.velocity = moveDir * speed;
                isMoving = true;
                if (BoxHP == 0)
                {
                    transform.position = boxSpawnLocation + new Vector3(0, 1.5f, 0);
                    boxRb.velocity = new Vector3(0, -0.1f, 0);
                    BoxHP = 2;
                }
            }
        }
    }
}
