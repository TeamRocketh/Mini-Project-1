using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravityScale = 10.0f;
    public static bool canDash, isDashing;
    Rigidbody rb;
    public float speed;
    public float dashSpeed, dashTime;
    float currentDashTime;
    [HideInInspector]public bool dashPress=false;
    [HideInInspector]public Vector3 dir = Vector3.zero;
    public static float globalGravity = -9.81f;

    void Start()
    {
        isDashing = false;
        canDash = true;
        rb = GetComponent<Rigidbody>();
        currentDashTime = dashTime;
    }
    
    void Update()
    {
        float moveX= Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        if (rb.velocity.y > 0)
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (!isDashing)
        {            
            if (!dashPress)
            {
                if (moveX == 0)
                {
                    rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
                }
                else
                {
                    rb.velocity = new Vector3(moveX * speed, rb.velocity.y, rb.velocity.z);
                }
                if (moveZ == 0)
                {
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
                }
                else
                {
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveZ * speed);
                }
                if (Input.GetKeyDown(KeyCode.Space) && canDash)
                {

                    dir = new Vector3(moveX, 0, moveZ);
                    dashPress = true;
                }
            }
            else if(rb.velocity!=Vector3.zero)
            {
                rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, Time.deltaTime*4);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                gravityScale = 0;
                rb.velocity = dir*dashSpeed;
                isDashing = true;
            }           
        }
        else
        {
            currentDashTime -= Time.deltaTime;
            if (currentDashTime <= 0)
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);                
            }
            if(currentDashTime <= -0.15f)
            {
                gravityScale = 10;
                isDashing = false;
                dashPress = false;
                dir = Vector3.zero;
                currentDashTime = dashTime;
            }
        }
    }

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }
}
