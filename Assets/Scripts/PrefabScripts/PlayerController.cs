using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float dashSpeed, dashTime;
    [SerializeField] float currentDashTime;
    bool isDashing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentDashTime = dashTime;
    }
    
    void Update()
    {
        float moveX= Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        if (!isDashing)
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

            if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.velocity = new Vector3(moveX * dashSpeed, rb.velocity.y, moveZ * dashSpeed);
                isDashing = true;
            }

            if (rb.velocity.y > 1f)
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            if (rb.velocity.y < 0)
                rb.velocity = new Vector3(rb.velocity.x, Mathf.Abs(1.3f * rb.velocity.y) * -1, rb.velocity.z);
        }
        else
        {
            currentDashTime -= Time.deltaTime;
            if (currentDashTime <= 0)
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
                isDashing = false;
                currentDashTime = dashTime;
            }
        }
    }
}
