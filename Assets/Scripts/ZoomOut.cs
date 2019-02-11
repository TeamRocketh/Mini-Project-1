using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    public float changeTo;

    bool trigger = false;
    float moveSpeed = 35;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            trigger = true;
        }
    }

    private void Update()
    {
        if (trigger)
        {
            if (changeTo > Camera.main.transform.localPosition.y)
            {
                Camera.main.transform.localPosition += new Vector3(0, Time.deltaTime * moveSpeed, 0);
                if (changeTo <= Camera.main.transform.localPosition.y)
                    trigger = false;
            }
            else if (changeTo < Camera.main.transform.localPosition.y)
            {
                Camera.main.transform.localPosition -= new Vector3(0, Time.deltaTime * moveSpeed, 0);
                if (changeTo >= Camera.main.transform.localPosition.y)
                    trigger = false;
            }
        }
    }
}
