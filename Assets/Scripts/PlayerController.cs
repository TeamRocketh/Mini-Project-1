using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravityScale = 10.0f;
    public static bool canDash, canLongDash, canStoreDash, isDashing, isLongDashing;
    public bool hasDashCoolDown;
    bool dashAvailable = true;
    Rigidbody rb;
    public float speed, dashSpeed, dashTime, cooldownTimer, longDashHoldTime;
    [HideInInspector] public float currentDashTime, currentCooldownTime, currentLongDashHoldTime;
    float tempDashTime, tempDashSpeed;
    [HideInInspector] public bool dashPress = false;
    [HideInInspector] public Vector3 dir = Vector3.zero;
    public static float globalGravity = -9.81f;
    public int currentDashCharge = 0;
    public static bool startingComplete = false;

    void Start()
    {
        tempDashSpeed = dashSpeed;
        tempDashTime = dashTime;
        isLongDashing = false;
        isDashing = false;
        rb = GetComponent<Rigidbody>();
        currentDashTime = dashTime;
        currentCooldownTime = cooldownTimer;
        currentLongDashHoldTime = longDashHoldTime;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        if (rb.velocity.y > 0)
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (!isDashing)
        {
            if (!dashPress || !canLongDash)
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
                    dashPress = true;
                }
            }
            else if (isLongDashing != true && canLongDash)
            {
                rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, Time.deltaTime * 20);
                if (currentLongDashHoldTime <= 0 && !canStoreDash)
                {
                    dashSpeed = 400;
                    dashTime = 0.04f;
                    currentDashTime = dashTime;
                }
                if (canStoreDash)
                {
                    currentDashTime = dashTime;
                    if (currentLongDashHoldTime <= 0 && currentLongDashHoldTime > -1 && currentDashCharge >= 1)
                    {
                        dashSpeed = 400;
                        dashTime = 0.04f;
                    }
                    else if (currentLongDashHoldTime <= -1 && currentLongDashHoldTime > -2 && currentDashCharge >= 2)
                    {
                        dashSpeed = 600;
                        dashTime = 0.04f;
                    }
                    else if (currentLongDashHoldTime <= -2 && currentDashCharge == 3)
                    {
                        dashSpeed = 800;
                        dashTime = 0.04f;

                    }

                }
            }

            if (Input.GetKeyUp(KeyCode.Space) && canDash && dashAvailable)
            {
                dir = new Vector3(moveX, 0, moveZ);
                if (hasDashCoolDown && dir != Vector3.zero)
                {
                    dashAvailable = false;
                }
                if (dashSpeed >= 400)
                {
                    isLongDashing = true;
                    switch (dashSpeed)
                    {
                        case 400:
                            currentDashCharge--;
                            break;
                        case 600:
                            currentDashCharge -= 2;
                            break;
                        case 800:
                            currentDashCharge -= 3;
                            break;
                    }
                }
                gravityScale = 0;
                rb.velocity = Vector3.zero;
                rb.velocity = dir * dashSpeed;
                dashPress = false;
                currentLongDashHoldTime = longDashHoldTime;
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
            if (currentDashTime <= -0.15f)
            {
                gravityScale = 10;
                isDashing = false;
                dir = Vector3.zero;
                dashTime = tempDashTime;
                dashSpeed = tempDashSpeed;
                currentDashTime = dashTime;
                isLongDashing = false;
            }
        }
        if (currentCooldownTime <= cooldownTimer)
        {
            currentCooldownTime -= Time.deltaTime;
            if (currentCooldownTime <= 0)
            {
                dashAvailable = true;
                currentCooldownTime = cooldownTimer;
                if (currentDashCharge < 3)
                {
                    currentDashCharge++;
                }
            }
        }
        if (dashPress)
        {
            currentLongDashHoldTime -= Time.deltaTime;
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
