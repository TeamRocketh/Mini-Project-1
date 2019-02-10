using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    public float doorSpeedClose;
    public float doorSpeedOpen;

    GameObject LD, RD;

    public bool cond = false;

    private void Start()
    {
        LD = door.transform.GetChild(0).gameObject;
        RD = door.transform.GetChild(1).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
            cond = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
            cond = false;
    }

    void Update()
    {
        if (!cond)
        {
            float temp = Time.deltaTime * doorSpeedClose;

            if (LD.transform.localPosition.x < 0)
                LD.transform.localPosition += new Vector3(temp, 0, 0);
            if (RD.transform.localPosition.x > 0)
                RD.transform.localPosition -= new Vector3(temp, 0, 0);
        }

        if (cond)
        {
            float temp = Time.deltaTime * doorSpeedOpen;

            if (LD.transform.localPosition.x > -1.2)
                LD.transform.localPosition -= new Vector3(temp, 0, 0);
            if (RD.transform.localPosition.x < 1.2)
                RD.transform.localPosition += new Vector3(temp, 0, 0);
        }
    }
}
