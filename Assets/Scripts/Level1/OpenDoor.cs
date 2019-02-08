using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    public float doorSpeed;

    GameObject LD, RD;

    public bool cond = false;
    public bool illuminate = false;

    private void Start()
    {
        LD = door.transform.GetChild(0).gameObject;
        RD = door.transform.GetChild(1).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            cond = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            cond = false;
    }

    void Update()
    {
        float temp = Time.deltaTime * doorSpeed;

        if (!cond)
        {
            if (LD.transform.localPosition.x < 0)
                LD.transform.localPosition += new Vector3(temp, 0, 0);
            if (RD.transform.localPosition.x > 0)
                RD.transform.localPosition -= new Vector3(temp, 0, 0);
        }

        if (cond)
        {
            if (LD.transform.localPosition.x > -1.2)
                LD.transform.localPosition -= new Vector3(temp, 0, 0);
            if (RD.transform.localPosition.x < 1.2)
                RD.transform.localPosition += new Vector3(temp, 0, 0);
        }

        if (illuminate && !cond)
        {
            LevelManager.ill = true;
        }
    }
}
